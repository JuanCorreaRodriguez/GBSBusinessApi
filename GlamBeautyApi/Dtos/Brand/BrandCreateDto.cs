using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.Unions;

namespace GBSApi.Dtos.Brand;

public class BrandCreateDto
{
    [Required(ErrorMessage = "Please enter a brand name")]
    [MaxLength(50)]

    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a brand description")]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(50)] public string? Ranking { get; set; } = string.Empty;

    public List<Ids>? Media { get; set; } = [];
}