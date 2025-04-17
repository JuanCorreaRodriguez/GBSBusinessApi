using GlamBeautyApi.Dtos.Brand;

namespace GlamBeautyApi.Interfaces.Brand;

public interface IBrandService
{
    Task<IEnumerable<BrandDto>> GetBrands();
    Task<BrandDto?> GetBrand(string brandId);
    Task<BrandDto> CreateBrand(BrandCreateDto brand);
    Task<BrandDto?> UpdateBrand(string id, BrandUpdateDto brand);
    Task<bool> DeleteBrand(string brandId);
    Task<bool> BrandExists(string brandId);
}