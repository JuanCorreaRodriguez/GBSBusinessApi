using GlamBeautyApi.Connections;
using GlamBeautyApi.Dtos.Brand;
using GlamBeautyApi.Dtos.Media;
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

    public async Task<IEnumerable<BrandMinDto>> GetBrands()
    {
        var brands = await _context.Brand
            .Select(brand => new BrandMinDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Description = brand.Description,
                Ranking = brand.Ranking,
                Media = brand.Media.Select(o => new MediaMinInnerDto
                {
                    Reference = o.Reference,
                    Metadata = o.Metadata
                }).ToList()
            })
            .ToListAsync();
        return brands;
    }

    public async Task<BrandMinDto?> GetBrand(string brandId)
    {
        var brand = await _context.Brand
            .Select(brand => new BrandMinDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Description = brand.Description,
                Ranking = brand.Ranking,
                Media = brand.Media.Select(o => new MediaMinInnerDto
                {
                    Reference = o.Reference,
                    Metadata = o.Metadata
                }).ToList()
            })
            .FirstOrDefaultAsync(o => o.BrandId == Guid.Parse(brandId));
        return brand;
    }

    public async Task<Brand?> GetBrandEntity(string brandId)
    {
        return await _context.Brand
            .FirstOrDefaultAsync(o => o.BrandId == Guid.Parse(brandId));
    }

    public async Task<Brand> PostBrand(Brand brand, List<Media> media)
    {
        var result = await _context.Brand.AddAsync(brand);
        if (media.Count > 0)
            foreach (var obj in media)
                result.Entity.Media.Add(obj);

        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Brand?> PutBrand(string id, BrandUpdateDto dto, List<Media> mediaList)
    {
        var brand = await _context.Brand.FirstOrDefaultAsync(o => o.BrandId == Guid.Parse(id));
        if (brand == null) return null;
        if (!string.IsNullOrEmpty(dto.Name)) brand.Name = dto.Name;
        if (!string.IsNullOrEmpty(dto.Description)) brand.Description = dto.Description;
        if (!string.IsNullOrEmpty(dto.Ranking)) brand.Ranking = dto.Ranking;
        if (mediaList.Count > 0)
            foreach (var media in mediaList)
                brand.Media.Add(media);

        await _context.SaveChangesAsync();
        return brand;
    }

    public async Task<bool> DeleteBrand(string brandId)
    {
        var brand = await GetBrandEntity(brandId);
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