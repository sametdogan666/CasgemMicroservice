using AutoMapper;
using CasgemMicroservice.Services.Catalog.DTOs.CategoryDTOs;
using CasgemMicroservice.Services.Catalog.Models;
using CasgemMicroservice.Services.Catalog.Settings;
using CasgemMicroservice.Shared.DTOs;
using MongoDB.Driver;

namespace CasgemMicroservice.Services.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

    }

    public async Task<Response<List<ResultCategoryDto>>> GetListCategoriesAsync()
    {
        var categories = await _categoryCollection.Find(x => true).ToListAsync();

        return Response<List<ResultCategoryDto>>.Success(_mapper.Map<List<ResultCategoryDto>>(categories), 200);
    }

    public async Task<Response<ResultCategoryDto>> GetCategoryAsync(string categoryId)
    {
        var category = await _categoryCollection.Find(x => x.Id == categoryId).FirstOrDefaultAsync();

        return category == null ? Response<ResultCategoryDto>.Fail("Böyle bir Id bulunamadı!", 404) : Response<ResultCategoryDto>.Success(_mapper.Map<ResultCategoryDto>(category), 200);
    }

    public async Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryCollection.InsertOneAsync(category);

        return Response<NoContent>.Success(200);
    }

    public async Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var result =
            await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == categoryDto.Id, category);

        return result == null ? Response<NoContent>.Fail("Güncellenecek kategori bulunamadı!", 404) : Response<NoContent>.Success(204);
    }

    public async Task<Response<NoContent>> DeleteCategoryAsync(string categoryId)
    {
        var category = await _categoryCollection.DeleteOneAsync(x => x.Id == categoryId);

        return category.DeletedCount > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Silinecek kategori bulunamadı!", 404);
    }
}