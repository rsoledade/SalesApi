using SalesApi.Application.DTO;

namespace SalesApi.Application.Interfaces
{
    public interface ISaleService
    {
        Task<bool> CancelSaleAsync(Guid saleId);
        Task<SaleDto> CreateSaleAsync(SaleDto dto);
        Task<IEnumerable<SaleDto>> GetAllSalesAsync();
    }
}
