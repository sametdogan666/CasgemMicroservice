using AutoMapper;
using CasgemMicroservice.Services.Catalog.DTOs.ProductDTOs;
using CasgemMicroservice.Services.Catalog.Models;
using CasgemMicroservice.Services.Catalog.Settings;
using CasgemMicroservice.Shared.DTOs;
using MongoDB.Driver;

namespace CasgemMicroservice.Services.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
    }

    public async Task<Response<List<ResultProductDto>>> GetListProductsAsync()
    {
        var products = await _productCollection.Find(x => true).ToListAsync();

        return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(products), 200);
    }

    public async Task<Response<ResultProductDto>> GetProductAsync(string productId)
    {
        var product = await _productCollection.Find(x => x.Id == productId).FirstOrDefaultAsync();

        return product == null ? Response<ResultProductDto>.Fail("Böyle bir Id bulunamadı!", 404) : Response<ResultProductDto>.Success(_mapper.Map<ResultProductDto>(product), 200);
    }

    public async Task<Response<NoContent>> CreateProductAsync(CreateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productCollection.InsertOneAsync(product);

        return Response<NoContent>.Success(294);
    }

    public async Task<Response<NoContent>> UpdateProductAsync(UpdateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var result =
            await _productCollection.FindOneAndReplaceAsync(x => x.Id == productDto.Id, product);

        return result == null ? Response<NoContent>.Fail("Güncellenecek ürün bulunamadı!", 404) : Response<NoContent>.Success(204);
    }

    public async Task<Response<NoContent>> DeleteProductAsync(string productId)
    {
        var product = await _productCollection.DeleteOneAsync(x => x.Id == productId);

        return product.DeletedCount > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Silinecek ürün bulunamadı!", 404);
    }

    public async Task<Response<List<ResultProductDto>>> GetListProductsWithCategoryAsync()
    {
        var values = await _productCollection.Find(x => true).ToListAsync();

        if (values.Any())
        {
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.Id == item.CategoryId).FirstOrDefaultAsync();
            }
        }
        else
        {
            values = new List<Product>();
        }

        return Response<List<ResultProductDto>>.Success(_mapper.Map<List<ResultProductDto>>(values), 200);
    }

}