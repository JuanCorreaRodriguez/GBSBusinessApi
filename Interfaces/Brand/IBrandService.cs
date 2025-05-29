using GBSApi.Dtos.Brand;

namespace GBSApi.Interfaces.Brand;

public interface IBrandService
{
    Task<IEnumerable<BrandMinDto>> GetBrands();
    Task<BrandMinDto?> GetBrand(string brandId);
    Task<BrandMinDto> CreateBrand(BrandCreateDto brand);
    Task<BrandMinDto?> UpdateBrand(string id, BrandUpdateDto brand);
    Task<bool> DeleteBrand(string brandId);
    Task<bool> BrandExists(string brandId);
}