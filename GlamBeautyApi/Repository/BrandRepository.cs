using GlamBeautyApi.Connections;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Brand;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Repository;

public class BrandRepository : IBrandRepository
{
    private readonly PostgreDbContext _context;

    public BrandRepository(PostgreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brand>> GetBrands()
    {
        var brands = await _context.Brand
            .Select(brand => new Brand
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Description = brand.Description,
                Ranking = brand.Ranking
                // Media = brand.Media
            })
            .ToListAsync();
        return brands;
    }

    public async Task<Brand?> GetBrand(string brandId)
    {
        var brand = await _context.Brand
            .Select(brand => new Brand
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Description = brand.Description,
                Ranking = brand.Ranking,
                Media = brand.Media
            })
            .FirstOrDefaultAsync(o => o.BrandId == Guid.Parse(brandId));
        return brand;
    }

    public async Task<Brand> PostBrand(Brand brand)
    {
        var result = await _context.Brand.AddAsync(brand);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Brand?> PutBrand(string id, Brand brandEntity)
    {
        var brand = await GetBrand(id);
        if (brand == null) return null;

        if (!string.IsNullOrEmpty(brandEntity.Name)) brand.Name = brandEntity.Name;
        if (!string.IsNullOrEmpty(brandEntity.Description)) brand.Description = brandEntity.Description;
        if (!string.IsNullOrEmpty(brandEntity.Ranking)) brand.Ranking = brandEntity.Ranking;

        await _context.SaveChangesAsync();
        return brand;
    }

    public async Task<bool> DeleteBrand(string brandId)
    {
        var brand = await GetBrand(brandId);
        if (brand == null) return false;
        _context.Brand.Remove(brand);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsBrand(string brandId)
    {
        return await _context.Brand.AnyAsync(o => o.BrandId == Guid.Parse(brandId));
    }
}