using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.Unions;

namespace GBSApi.Dtos.Category;

public class CategoryCreateDto
{
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;

    [MaxLength(50, ErrorMessage = "ParentId cannot be longer than 50 characters.")]
    public string? ParentId { get; set; }

    [MaxLength(50, ErrorMessage = "Category type cannot be longer than 50 characters.")]
    public string CategoryType { get; set; } = string.Empty;

    public List<Ids>? Media { get; set; } = [];
}