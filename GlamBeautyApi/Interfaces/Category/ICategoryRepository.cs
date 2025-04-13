using GlamBeautyApi.Dtos.Category;

namespace GlamBeautyApi.Interfaces.Category;

public interface ICategoryRepository
{
    Task<IEnumerable<Entities.Category>> GetCategories();
    Task<Entities.Category?> GetCategory(string id);
    Task<Entities.Category> PostCategory(CategoryCreateDto category);
    Task<bool> ExistCategoryAsync(string id);
    Task<CategoryUpdateDto?> PutCategory(string id, CategoryUpdateDto category);
    Task<string?> DeleteCategory(string id);
}