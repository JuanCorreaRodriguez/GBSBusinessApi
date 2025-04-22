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
            Ranking = brand.Ranking!
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

    public static BrandMinDto EntityToDto(this Brand brand)
    {
        return new BrandMinDto
        {
            BrandId = brand.BrandId,
            Name = brand.Name,
            Description = brand.Description,
            Ranking = brand.Ranking,
            Media = brand.Media.Select(o => o.EntityToMinInnerDto()).ToList()
        };
    }
}