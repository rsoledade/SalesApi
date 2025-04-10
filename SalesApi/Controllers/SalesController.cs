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
            return Ok(new { dados = sales, status = "sucesso", message = "Operação concluída com sucesso" });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleDto dto)
        {
            var sale = await _saleService.CreateSaleAsync(dto);
            return Ok(new { dados = sale, status = "sucesso", message = "Venda realizada com sucesso" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var result = await _saleService.CancelSaleAsync(id);
            if (!result)
                return NotFound(new { dados = (object)null, status = "erro", message = "Venda não encontrada ou já cancelada" });

            return Ok(new { dados = (object)null, status = "sucesso", message = "Venda cancelada com sucesso" });
        }
    }
}
