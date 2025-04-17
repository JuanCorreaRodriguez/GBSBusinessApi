using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Category;

public class CategoryDto
{
    [MaxLength(50)] public Guid CategoryId { get; set; }

    [MaxLength(50)] public required string Name { get; set; }

    [MaxLength(1000)] public string Desc { get; set; } = string.Empty;

    [MaxLength(200)] public string Type { get; set; } = string.Empty;

    // [MaxLength(50)] public Guid? ParentId { get; set; } = null!;

    public ICollection<SubcategoryDto>? SubCategories { get; set; } = [];
}