using CasgemMicroservice.Services.Catalog.DTOs.ProductDTOs;
using CasgemMicroservice.Services.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-list-products")]
        public async Task<IActionResult> GetListProducts()
        {
            var categories = await _productService.GetListProductsAsync();

            return Ok(categories);
        }

        [HttpGet("get-by-id-product/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute(Name = "id")] string id)
        {
            var category = await _productService.GetProductAsync(id);

            return Ok(category);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            await _productService.CreateProductAsync(productDto);

            return Ok();
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute(Name = "id")] string id)
        {
            await _productService.DeleteProductAsync(id);

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            await _productService.UpdateProductAsync(productDto);

            return Ok();
        }
    }
}
