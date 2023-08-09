using CasgemMicroservice.Services.Catalog.DTOs.CategoryDTOs;
using CasgemMicroservice.Services.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-list-categories")]
        public async Task<IActionResult> GetListCategories()
        {
            var categories = await _categoryService.GetListCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet("get-by-id-category/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute(Name = "id")] string id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            return Ok(category);
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            await _categoryService.CreateCategoryAsync(categoryDto);

            return Ok();
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] string id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return Ok();
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(categoryDto);

            return Ok();
        }
    }
}
