using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Mappers;

public static class MediaMapper
{
    public static Media DtoToEntity(this MediaDto dto)
    {
        return new Media
        {
            Name = dto.Name,
            Metadata = dto.Metadata,
            Reference = dto.Reference,
            MediaId = dto.MediaId
        };
    }

    public static Media CreateToEntity(this MediaCreateDto dto)
    {
        return new Media
        {
            Name = dto.Name,
            Metadata = dto.Metadata!,
            Reference = dto.Reference
        };
    }

    public static Media UpdateToEntity(this MediaUpdateDto dto)
    {
        return new Media
        {
            Name = dto.Name,
            Metadata = dto.Metadata!,
            Reference = dto.Reference!
        };
    }

    public static MediaDto EntityToDto(this Media entity)
    {
        return new MediaDto
        {
            Name = entity.Name,
            Metadata = entity.Metadata,
            Reference = entity.Reference,
            MediaId = entity.MediaId
        };
    }

    public static MediaMinInnerDto EntityToMinInnerDto(this Media entity)
    {
        return new MediaMinInnerDto
        {
            Name = entity.Name,
            Metadata = entity.Metadata,
            Reference = entity.Reference
        };
    }

    public static MediaMinDto EntityToMinDto(this Media entity)
    {
        return new MediaMinDto
        {
            Name = entity.Name,
            Metadata = entity.Metadata,
            Reference = entity.Reference
        };
    }
}