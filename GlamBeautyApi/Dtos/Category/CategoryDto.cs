using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Category;

public class CategoryDto
{
    [MaxLength(50)] public Guid CategoryId { get; set; }

    [MaxLength(50)] public required string CategoryName { get; set; }

    [MaxLength(1000)] public string CategoryDesc { get; set; } = string.Empty;

    [MaxLength(50)] public Guid? ParentId { get; set; } = Guid.Empty;

    [MaxLength(200)] public string CategoryType { get; set; } = string.Empty;
}