using GlamBeautyApi.Dtos.Brand;
using GlamBeautyApi.Interfaces.Brand;
using GlamBeautyApi.Mappers;

namespace GlamBeautyApi.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<BrandDto>> GetBrands()
    {
        var brandsEntity = await _brandRepository.GetBrands();
        var brands = brandsEntity.Select(o => o.EntityToDto());
        return brands;
    }

    public async Task<BrandDto?> GetBrand(string brandId)
    {
        var brand = await _brandRepository.GetBrand(brandId);
        return brand?.EntityToDto();
    }

    public async Task<BrandDto> CreateBrand(BrandCreateDto brand)
    {
        var result = await _brandRepository.PostBrand(brand.CreateDtoToEntity());
        return result.EntityToDto();
    }

    public async Task<BrandDto?> UpdateBrand(string id, BrandUpdateDto brand)
    {
        var result = await _brandRepository.PutBrand(id, brand.UpdateDtoToEntity());
        return result?.EntityToDto();
    }

    public async Task<bool> DeleteBrand(string brandId)
    {
        return await _brandRepository.DeleteBrand(brandId);
    }

    public async Task<bool> BrandExists(string brandId)
    {
        return await _brandRepository.ExistsBrand(brandId);
    }
}