using GlamBeautyApi.Connections;
using GlamBeautyApi.Dtos.Category;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Category;
using GlamBeautyApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Repository;

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
                Name = category.CategoryName,
                CategoryId = category.CategoryId,
                Desc = category.CategoryDesc,
                Type = category.CategoryType,
                SubCategories = category.SubCategories.Select(sub => new SubcategoryDto
                {
                    Name = sub.CategoryName,
                    CategoryId = sub.CategoryId,
                    Desc = sub.CategoryDesc,
                    Type = sub.CategoryType,
                    ParentId = sub.ParentId
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
                Name = category.CategoryName,
                CategoryId = category.CategoryId,
                Desc = category.CategoryDesc,
                Type = category.CategoryType
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<SubcategoryDto>> GetSubCategories()
    {
        return await _context.Categories
            .Where(o => o.ParentId != null)
            .Select(category => new SubcategoryDto
            {
                Name = category.CategoryName,
                CategoryId = category.CategoryId,
                Desc = category.CategoryDesc,
                Type = category.CategoryType,
                ParentId = category.ParentId
            })
            .ToListAsync();
    }

    public async Task<CategoryDto?> GetCategory(string id)
    {
        return await _context.Categories
            .Select(category => new CategoryDto
            {
                Name = category.CategoryName,
                CategoryId = category.CategoryId,
                Desc = category.CategoryDesc,
                Type = category.CategoryType,
                SubCategories = category.SubCategories.Select(sub => new SubcategoryDto
                {
                    Name = sub.CategoryName,
                    CategoryId = sub.CategoryId,
                    Desc = sub.CategoryDesc,
                    Type = sub.CategoryType,
                    ParentId = sub.ParentId
                }).ToList()
            })
            .FirstAsync(o => o.CategoryId.ToString() == id);
    }

    public async Task<Category?> GetCategoryEntity(string id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(o => o.CategoryId == Guid.Parse(id))!;
    }

    public async Task<Category> PostCategory(CategoryCreateDto category)
    {
        // try
        // {
        //
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        // }
        var cat = category.CreateDtoToModel();
        Console.WriteLine("*** POSTING ***");
        Console.WriteLine(cat.CategoryName);
        Console.WriteLine(cat.CategoryType);
        var categoryRes = await _context.Categories.AddAsync(category.CreateDtoToModel());
        await _context.SaveChangesAsync();
        return categoryRes.Entity;
    }

    public Task<bool> ExistCategoryAsync(string id)
    {
        return _context.Categories.AnyAsync(o => o.CategoryId.ToString() == id);
    }

    public async Task<CategoryUpdateDto?> PutCategory(string id, CategoryUpdateDto dto)
    {
        var category = await GetCategoryEntity(id);

        if (category == null) return null;

        if (!string.IsNullOrEmpty(dto.CategoryName)) category.CategoryName = dto.CategoryName;
        if (!string.IsNullOrEmpty(dto.CategoryDesc)) category.CategoryDesc = dto.CategoryDesc;
        if (!string.IsNullOrEmpty(dto.CategoryType)) category.CategoryType = dto.CategoryType;

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