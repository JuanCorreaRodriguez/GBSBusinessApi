using GlamBeautyApi.Dtos.Category;

namespace GlamBeautyApi.Interfaces.Category;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryDto>> GetAllCategories();
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<IEnumerable<SubcategoryDto>> GetSubCategories();
    Task<CategoryDto?> GetCategory(string id);
    Task<Entities.Category?> GetCategoryEntity(string id);
    Task<Entities.Category> PostCategory(CategoryCreateDto category);
    Task<bool> ExistCategoryAsync(string id);
    Task<CategoryUpdateDto?> PutCategory(string id, CategoryUpdateDto category);
    Task<string?> DeleteCategory(string id);
}