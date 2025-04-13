using GlamBeautyApi.Dtos.Category;
using GlamBeautyApi.Interfaces.Category;
using GlamBeautyApi.Mappers;

namespace GlamBeautyApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        var categoriesModel = await _categoryRepository.GetCategories();
        var categories = categoriesModel.Select(o => o.ModelToDto());
        return categories;
    }

    public async Task<CategoryDto?> GetCategory(string id)
    {
        var cat = await _categoryRepository.GetCategory(id);
        return cat?.ModelToDto();
    }

    public async Task<CategoryCreateDto> CreateCategory(CategoryCreateDto category)
    {
        var categoryRes = await _categoryRepository.PostCategory(category);
        return categoryRes.ModelToCreateDto();
    }

    public async Task<CategoryUpdateDto?> UpdateCategory(string id, CategoryUpdateDto category)
    {
        return await _categoryRepository.PutCategory(id, category)!;
    }

    public async Task<string?> DeleteCategory(string id)
    {
        return await _categoryRepository.DeleteCategory(id);
    }
}