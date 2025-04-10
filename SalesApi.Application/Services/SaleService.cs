using AutoMapper;
using SalesApi.Domain.Events;
using SalesApi.Domain.Entities;
using SalesApi.Application.DTO;
using SalesApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SalesApi.Application.Interfaces;

namespace SalesApi.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly SalesDbContext _context;
        private readonly IEventPublisher _eventPublisher;

        public SaleService(SalesDbContext context, IEventPublisher eventPublisher, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public async Task<IEnumerable<SaleDto>> GetAllSalesAsync()
        {
            var sales = await _context.Sales.Include(s => s.Items).ToListAsync();
            return _mapper.Map<IEnumerable<SaleDto>>(sales);
        }

        public async Task<SaleDto> CreateSaleAsync(SaleDto dto)
        {
            var sale = _mapper.Map<Sale>(dto);
            sale.Id = Guid.NewGuid();
            sale.Date = dto.Date;
            sale.IsCancelled = false;

            foreach (var item in sale.Items)
            {
                item.Id = Guid.NewGuid();
                item.ApplyTaxRules();
            }

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            await _eventPublisher.PublishAsync(new SaleCreatedEvent
            {
                SaleId = sale.Id,
                Customer = sale.Customer,
                Branch = sale.Branch,
                Date = DateTime.UtcNow,
                TotalAmount = sale.GetTotalAmount()
            });

            return _mapper.Map<SaleDto>(sale);
        }

        public async Task<bool> CancelSaleAsync(Guid saleId)
        {
            var sale = await _context.Sales.FindAsync(saleId);
            if (sale == null || sale.IsCancelled) return false;

            sale.IsCancelled = true;
            await _context.SaveChangesAsync();

            var @event = new SaleCancelledEvent
            {
                SaleId = sale.Id,
                CancelledAt = DateTime.UtcNow
            };

            await _eventPublisher.PublishAsync(@event);

            return true;
        }
    }
}
