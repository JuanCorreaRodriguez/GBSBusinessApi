using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Mappers;

public static class MediaMapper
{
    public static Media DtoToEntity(this MediaDto dto)
    {
        return new Media
        {
            Metadata = dto.Metadata,
            Reference = dto.Reference,
            MediaId = dto.MediaId
        };
    }

    public static Media CreateToEntity(this MediaCreateDto dto)
    {
        return new Media
        {
            Metadata = dto.Metadata!,
            Reference = dto.Reference
        };
    }

    public static Media UpdateToEntity(this MediaUpdateDto dto)
    {
        return new Media
        {
            Metadata = dto.Metadata!,
            Reference = dto.Reference!,
            MediaId = dto.MediaId
        };
    }

    public static MediaDto EntityToDto(this Media entity)
    {
        return new MediaDto
        {
            Metadata = entity.Metadata,
            Reference = entity.Reference,
            MediaId = entity.MediaId
        };
    }
}