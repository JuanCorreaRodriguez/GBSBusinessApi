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
            CategoryName = model.CategoryName,
            CategoryDesc = model.CategoryDesc,
            CategoryType = model.CategoryName,
            ParentId = model.ParentId
        };
    }

    public static CategoryCreateDto ModelToCreateDto(this Category model)
    {
        return new CategoryCreateDto
        {
            CategoryName = model.CategoryName,
            CategoryDesc = model.CategoryDesc,
            CategoryType = model.CategoryName,
            ParentId = model.ParentId
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
            CategoryDesc = dto.CategoryDesc,
            CategoryName = dto.CategoryName,
            ParentId = dto.ParentId,
            CategoryType = dto.CategoryType
        };
    }

    public static Category CreateDtoToModel(this CategoryCreateDto createDto)
    {
        return new Category
        {
            CategoryDesc = createDto.CategoryDesc,
            CategoryName = createDto.CategoryName,
            ParentId = createDto.ParentId,
            CategoryType = createDto.CategoryType
        };
    }
}