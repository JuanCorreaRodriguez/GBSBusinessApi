namespace GlamBeautyApi.Interfaces.Brand;

public interface IBrandRepository
{
    Task<IEnumerable<Entities.Brand>> GetBrands();
    Task<Entities.Brand?> GetBrand(string brandId);
    Task<Entities.Brand> PostBrand(Entities.Brand brand);
    Task<Entities.Brand?> PutBrand(string id, Entities.Brand brand);
    Task<bool> DeleteBrand(string brandId);
    Task<bool> ExistsBrand(string brandId);
}