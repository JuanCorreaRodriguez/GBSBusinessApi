using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Category;

public class CategoryCreateDto
{
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public required string CategoryName { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string CategoryDesc { get; set; } = string.Empty;

    public Guid? ParentId { get; set; }

    [Required(ErrorMessage = "Category type is required")]
    [MaxLength(50, ErrorMessage = "Category type cannot be longer than 50 characters.")]
    public string CategoryType { get; set; } = string.Empty;
}