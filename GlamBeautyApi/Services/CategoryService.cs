using GBSApi.Dtos.Category;
using GBSApi.Entities;
using GBSApi.Interfaces.Category;
using GBSApi.Interfaces.Media;
using GBSApi.Mappers;

namespace GBSApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMediaRepository _mediaRepository;

    public CategoryService(ICategoryRepository categoryRepository, IMediaRepository mediaRepository)
    {
        _categoryRepository = categoryRepository;
        _mediaRepository = mediaRepository;
    }

    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        var categories = await _categoryRepository.GetAllCategories();
        return categories;
    }

    public async Task<IEnumerable<CategoryMinDto>> GetCategories()
    {
        var categories = await _categoryRepository.GetCategories();
        return categories.Select(o => o.DtoToMin());
    }

    public async Task<IEnumerable<SubcategoryDto>> GetSubCategories()
    {
        var categories = await _categoryRepository.GetSubCategories();
        return categories;
    }

    public async Task<CategoryDto?> GetCategory(string id)
    {
        var cat = await _categoryRepository.GetCategory(id);
        return cat;
    }

    public async Task<CategoryCreateDto> CreateCategory(CategoryCreateDto category)
    {
        List<Media> media = [];
        if (category.Media != null) media = await _mediaRepository.GetMediaFromList(category.Media);

        var categoryRes = await _categoryRepository.PostCategory(category.CreateDtoToModel(), media);
        return categoryRes.ModelToCreateDto();
    }

    public async Task<CategoryUpdateDto?> UpdateCategory(string id, CategoryUpdateDto category)
    {
        List<Media> media = [];
        if (category.Media != null) media = await _mediaRepository.GetMediaFromList(category.Media);

        return await _categoryRepository.PutCategory(id, category, media)!;
    }

    public async Task<string?> DeleteCategory(string id)
    {
        return await _categoryRepository.DeleteCategory(id);
    }
}