using GBSApi.Dtos.Category;
using GBSApi.Entities;

namespace GBSApi.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ModelToDto(this Category model)
    {
        return new CategoryDto
        {
            CategoryId = model.CategoryId,
            Name = model.Name,
            Desc = model.Description,
            Type = model.Name
        };
    }

    public static CategoryMinDto DtoToMin(this CategoryDto model)
    {
        return new CategoryMinDto
        {
            CategoryId = model.CategoryId,
            Name = model.Name,
            Desc = model.Desc,
            Type = model.Type,
            Media = model.Media
        };
    }

    public static CategoryMinDto ModelToMin(this Category model)
    {
        return new CategoryMinDto
        {
            CategoryId = model.CategoryId,
            Name = model.Name,
            Desc = model.Description,
            Type = model.Type
        };
    }

    public static CategoryCreateDto ModelToCreateDto(this Category model)
    {
        return new CategoryCreateDto
        {
            Name = model.Name,
            Description = model.Description,
            CategoryType = model.Name,
            ParentId = model.ParentId!.ToString()
        };
    }

    public static CategoryUpdateDto ModelToUpdateDto(this Category model)
    {
        return new CategoryUpdateDto
        {
            CategoryName = model.Name,
            CategoryDesc = model.Description,
            CategoryType = model.Name,
            ParentId = model.ParentId
        };
    }

    public static Category DtoToModel(this CategoryDto dto)
    {
        return new Category
        {
            Description = dto.Desc,
            Name = dto.Name,
            // ParentId = dto.ParentId,
            Type = dto.Type
        };
    }

    public static Category CreateDtoToModel(this CategoryCreateDto createDto)
    {
        return new Category
        {
            Description = createDto.Description,
            Name = createDto.Name,
            ParentId = createDto.ParentId != null ? new Guid(createDto.ParentId!) : null,
            Type = createDto.CategoryType
        };
    }
}