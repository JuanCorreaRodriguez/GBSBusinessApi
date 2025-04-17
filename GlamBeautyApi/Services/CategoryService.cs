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