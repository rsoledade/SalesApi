using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.DTO;
using SalesApi.Application.Interfaces;

namespace SalesApi.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(new { dados = products, status = "success", message = "Operation completed successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            var product = await _productService.CreateProductAsync(dto);
            return Ok(new { dados = product, status = "success", message = "Product created successfully" });
        }
    }
}
