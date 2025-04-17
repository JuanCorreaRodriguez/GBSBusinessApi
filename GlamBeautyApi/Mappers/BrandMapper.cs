using GlamBeautyApi.Dtos.Brand;
using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Mappers;

public static class BrandMapper
{
    public static Brand DtoToEntity(this BrandDto brand)
    {
        return new Brand
        {
            Name = brand.Name,
            Description = brand.Description,
            Ranking = brand.Ranking,
            BrandId = brand.BrandId
        };
    }

    public static Brand CreateDtoToEntity(this BrandCreateDto brand)
    {
        return new Brand
        {
            Name = brand.Name,
            Description = brand.Description,
            Ranking = brand.Ranking
        };
    }

    public static Brand UpdateDtoToEntity(this BrandUpdateDto brand)
    {
        return new Brand
        {
            Name = brand.Name!,
            Description = brand.Description!,
            Ranking = brand.Ranking!
        };
    }

    public static BrandDto EntityToDto(this Brand brand)
    {
        return new BrandDto
        {
            BrandId = brand.BrandId,
            Name = brand.Name,
            Description = brand.Description,
            Ranking = brand.Ranking
        };
    }
}