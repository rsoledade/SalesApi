using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.DTO;
using SalesApi.Application.Interfaces;

namespace SalesApi.Controllers
{
    [ApiController]
    [Route("vendas")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return Ok(new { dados = sales, status = "success", message = "Operation completed successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleDto dto)
        {
            try
            {
                var sale = await _saleService.CreateSaleAsync(dto);
                return Ok(new { dados = sale, status = "success", message = "Successful sale" });
            }
            catch (Exception ex)
            {
                return Ok(new { dados = (object)null, status = "information", message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var result = await _saleService.CancelSaleAsync(id);
            if (!result)
                return NotFound(new { dados = (object)null, status = "information", message = "Sale not found or already cancelled" });

            return Ok(new { dados = (object)null, status = "success", message = "Sale cancelled successfully" });
        }
    }
}
