using GBSApi.Dtos.Category;

namespace GBSApi.Interfaces.Category;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryDto>> GetAllCategories();
    Task<IEnumerable<CategoryDto>> GetCategories();
    Task<IEnumerable<SubcategoryDto>> GetSubCategories();
    Task<CategoryDto?> GetCategory(string id);
    Task<Entities.Category?> GetCategoryEntity(string id);
    Task<Entities.Category> PostCategory(Entities.Category category, List<Entities.Media> media);
    Task<bool> ExistCategoryAsync(string id);
    Task<CategoryUpdateDto?> PutCategory(string id, CategoryUpdateDto category, List<Entities.Media> media);
    Task<string?> DeleteCategory(string id);
}