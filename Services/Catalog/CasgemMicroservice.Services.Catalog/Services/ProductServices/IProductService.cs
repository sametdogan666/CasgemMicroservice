using CasgemMicroservice.Services.Catalog.DTOs.ProductDTOs;
using CasgemMicroservice.Shared.DTOs;

namespace CasgemMicroservice.Services.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<Response<List<ResultProductDto>>> GetListProductsAsync();
    Task<Response<ResultProductDto>> GetProductAsync(string productId);
    Task<Response<NoContent>> CreateProductAsync(CreateProductDto productDto);
    Task<Response<NoContent>> UpdateProductAsync(UpdateProductDto productDto);
    Task<Response<NoContent>> DeleteProductAsync(string productId);
    Task<Response<List<ResultProductDto>>> GetListProductsWithCategoryAsync();
}