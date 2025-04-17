using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Category;

public class CategoryCreateDto
{
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Desc { get; set; } = string.Empty;

    [MaxLength(50, ErrorMessage = "ParentId cannot be longer than 50 characters.")]
    public string? ParentId { get; set; }

    [MaxLength(50, ErrorMessage = "Category type cannot be longer than 50 characters.")]
    public string CategoryType { get; set; } = string.Empty;
}