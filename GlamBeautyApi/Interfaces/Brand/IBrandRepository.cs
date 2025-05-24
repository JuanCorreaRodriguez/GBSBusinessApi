using GBSApi.Dtos.Brand;

namespace GBSApi.Interfaces.Brand;

public interface IBrandRepository
{
    Task<IEnumerable<BrandMinDto>> GetBrands();
    Task<BrandMinDto?> GetBrand(string brandId);
    Task<Entities.Brand?> GetBrandEntity(string brandId);
    Task<Entities.Brand> PostBrand(Entities.Brand brand, List<Entities.Media> media);
    Task<Entities.Brand?> PutBrand(string id, BrandUpdateDto brand, List<Entities.Media> mediaList);
    Task<bool> DeleteBrand(string brandId);
    Task<bool> ExistsBrand(string brandId);
}