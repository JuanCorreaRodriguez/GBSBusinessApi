using GlamBeautyApi.Dtos.Brand;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Brand;
using GlamBeautyApi.Interfaces.Media;
using GlamBeautyApi.Mappers;

namespace GlamBeautyApi.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMediaRepository _mediaRepository;

    public BrandService(IBrandRepository brandRepository, IMediaRepository mediaRepository)
    {
        _brandRepository = brandRepository;
        _mediaRepository = mediaRepository;
    }

    public async Task<IEnumerable<BrandMinDto>> GetBrands()
    {
        var brands = await _brandRepository.GetBrands();
        return brands;
    }

    public async Task<BrandMinDto?> GetBrand(string brandId)
    {
        var brand = await _brandRepository.GetBrand(brandId);
        return brand;
    }

    public async Task<BrandMinDto> CreateBrand(BrandCreateDto brand)
    {
        List<Media> media = [];

        if (brand.Media != null) media = await _mediaRepository.GetMediaFromList(brand.Media!);

        var result = await _brandRepository.PostBrand(brand.CreateDtoToEntity(), media);
        return result.EntityToDto();
    }

    public async Task<BrandMinDto?> UpdateBrand(string id, BrandUpdateDto brand)
    {
        List<Media> mediaList = [];
        if (brand.Media != null)
        {
            var mediasId = brand.Media;
            mediaList = await _mediaRepository.GetMediaFromList(mediasId);
        }

        var result = await _brandRepository.PutBrand(id, brand, mediaList);
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