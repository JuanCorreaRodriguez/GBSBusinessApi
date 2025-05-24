using GBSApi.Dtos.Category;

namespace GBSApi.Interfaces.Category;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAll();
    Task<IEnumerable<CategoryMinDto>> GetCategories();
    Task<IEnumerable<SubcategoryDto>> GetSubCategories();
    Task<CategoryDto?> GetCategory(string id);
    Task<CategoryCreateDto> CreateCategory(CategoryCreateDto category);
    Task<CategoryUpdateDto?> UpdateCategory(string id, CategoryUpdateDto category);
    Task<string?> DeleteCategory(string id);
}