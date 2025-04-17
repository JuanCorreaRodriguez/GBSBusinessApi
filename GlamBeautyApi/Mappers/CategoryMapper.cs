using GlamBeautyApi.Dtos.Category;
using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ModelToDto(this Category model)
    {
        return new CategoryDto
        {
            CategoryId = model.CategoryId,
            Name = model.CategoryName,
            Desc = model.CategoryDesc,
            Type = model.CategoryName
        };
    }

    public static CategoryMinDto DtoToMin(this CategoryDto model)
    {
        return new CategoryMinDto
        {
            CategoryId = model.CategoryId,
            Name = model.Name,
            Desc = model.Desc,
            Type = model.Type
        };
    }

    public static CategoryMinDto ModelToMin(this Category model)
    {
        return new CategoryMinDto
        {
            CategoryId = model.CategoryId,
            Name = model.CategoryName,
            Desc = model.CategoryDesc,
            Type = model.CategoryType
        };
    }

    public static CategoryCreateDto ModelToCreateDto(this Category model)
    {
        return new CategoryCreateDto
        {
            Name = model.CategoryName,
            Desc = model.CategoryDesc,
            CategoryType = model.CategoryName,
            ParentId = model.ParentId!.ToString()
        };
    }

    public static CategoryUpdateDto ModelToUpdateDto(this Category model)
    {
        return new CategoryUpdateDto
        {
            CategoryName = model.CategoryName,
            CategoryDesc = model.CategoryDesc,
            CategoryType = model.CategoryName,
            ParentId = model.ParentId
        };
    }

    public static Category DtoToModel(this CategoryDto dto)
    {
        return new Category
        {
            CategoryDesc = dto.Desc,
            CategoryName = dto.Name,
            // ParentId = dto.ParentId,
            CategoryType = dto.Type
        };
    }

    public static Category CreateDtoToModel(this CategoryCreateDto createDto)
    {
        return new Category
        {
            CategoryDesc = createDto.Desc,
            CategoryName = createDto.Name,
            ParentId = new Guid(createDto.ParentId!),
            CategoryType = createDto.CategoryType
        };
    }
}