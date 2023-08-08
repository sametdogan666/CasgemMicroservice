using CasgemMicroservice.Services.Catalog.DTOs.CategoryDTOs;
using CasgemMicroservice.Shared.DTOs;

namespace CasgemMicroservice.Services.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task<Response<List<ResultCategoryDto>>> GetListCategoriesAsync();
    Task<Response<ResultCategoryDto>> GetCategoryAsync(string categoryId);
    Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDto categoryDto);
    Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDto categoryDto);
    Task<Response<NoContent>> DeleteCategoryAsync(string categoryId);
}