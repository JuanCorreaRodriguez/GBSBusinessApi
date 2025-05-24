using GBSApi.Connections;
using GBSApi.Dtos.Category;
using GBSApi.Dtos.Media;
using GBSApi.Entities;
using GBSApi.Interfaces.Category;
using GBSApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GBSApi.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly PostgreDbContext _context;

    public CategoryRepository(PostgreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        return await _context.Categories
            .Where(o => o.ParentId == null)
            .Select(category => new CategoryDto
            {
                Name = category.Name,
                CategoryId = category.CategoryId,
                Desc = category.Description,
                Type = category.Type,
                SubCategories = category.SubCategories.Select(sub => new SubcategoryDto
                {
                    Name = sub.Name,
                    CategoryId = sub.CategoryId,
                    Desc = sub.Description,
                    Type = sub.Type,
                    ParentId = sub.ParentId
                }).ToList(),
                Media = category.Media.Select(o => new MediaMinInnerDto
                {
                    Metadata = o.Metadata,
                    Reference = o.Reference
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        return await _context.Categories
            .Where(o => o.ParentId == null)
            .Select(category => new CategoryDto
            {
                Name = category.Name,
                CategoryId = category.CategoryId,
                Desc = category.Description,
                Type = category.Type,
                Media = category.Media.Select(o => new MediaMinInnerDto
                {
                    Metadata = o.Metadata,
                    Reference = o.Reference
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<SubcategoryDto>> GetSubCategories()
    {
        return await _context.Categories
            .Where(o => o.ParentId != null)
            .Select(category => new SubcategoryDto
            {
                Name = category.Name,
                CategoryId = category.CategoryId,
                Desc = category.Description,
                Type = category.Type,
                ParentId = category.ParentId,
                Media = category.Media.Select(o => new MediaMinInnerDto
                {
                    Metadata = o.Metadata,
                    Reference = o.Reference
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<CategoryDto?> GetCategory(string id)
    {
        return await _context.Categories
            .Select(category => new CategoryDto
            {
                Name = category.Name,
                CategoryId = category.CategoryId,
                Desc = category.Description,
                Type = category.Type,
                SubCategories = category.SubCategories.Select(sub => new SubcategoryDto
                {
                    Name = sub.Name,
                    CategoryId = sub.CategoryId,
                    Desc = sub.Description,
                    Type = sub.Type,
                    ParentId = sub.ParentId
                }).ToList(),
                Media = category.Media.Select(o => new MediaMinInnerDto
                {
                    Metadata = o.Metadata,
                    Reference = o.Reference
                }).ToList()
            })
            .FirstAsync(o => o.CategoryId.ToString() == id);
    }

    public async Task<Category?> GetCategoryEntity(string id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(o => o.CategoryId == Guid.Parse(id))!;
    }

    public async Task<Category> PostCategory(Category category, List<Media> media)
    {
        var categoryRes = await _context.Categories.AddAsync(category);

        if (media.Count > 0)
            foreach (var obj in media)
                categoryRes.Entity.Media.Add(obj);

        await _context.SaveChangesAsync();
        return categoryRes.Entity;
    }

    public Task<bool> ExistCategoryAsync(string id)
    {
        return _context.Categories.AnyAsync(o => o.CategoryId.ToString() == id);
    }

    public async Task<CategoryUpdateDto?> PutCategory(string id, CategoryUpdateDto dto, List<Media> media)
    {
        var category = await GetCategoryEntity(id);

        if (category == null) return null;

        if (!string.IsNullOrEmpty(dto.CategoryName)) category.Name = dto.CategoryName;
        if (!string.IsNullOrEmpty(dto.CategoryDesc)) category.Description = dto.CategoryDesc;
        if (!string.IsNullOrEmpty(dto.CategoryType)) category.Type = dto.CategoryType;

        if (media.Count > 0)
            foreach (var obj in media)
                category.Media.Add(obj);

        await _context.SaveChangesAsync();
        return category.ModelToUpdateDto();
    }

    public async Task<string?> DeleteCategory(string id)
    {
        var category = await GetCategoryEntity(id);

        if (category == null) return null;
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return id;
    }
}