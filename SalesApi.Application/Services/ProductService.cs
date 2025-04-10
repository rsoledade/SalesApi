using AutoMapper;
using SalesApi.Domain.Events;
using SalesApi.Domain.Entities;
using SalesApi.Application.DTO;
using SalesApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SalesApi.Application.Interfaces;

namespace SalesApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly SalesDbContext _context;
        private readonly IEventPublisher _eventPublisher;

        public ProductService(SalesDbContext context, IEventPublisher eventPublisher, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            await _eventPublisher.PublishAsync(new ProductCreatedEvent
            {
                ProductId = product.Id,
                Name = product.Name,
                UnitPrice = product.UnitPrice
            });

            return _mapper.Map<ProductDto>(product);
        }
    }
}
