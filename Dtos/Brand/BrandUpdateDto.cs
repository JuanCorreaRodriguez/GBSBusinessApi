using System.ComponentModel.DataAnnotations;

namespace GBSApi.Dtos.Brand;

public class BrandUpdateDto
{
    [MaxLength(50)] public string? Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

    [MaxLength(50)] public string? Ranking { get; set; } = string.Empty;

    public List<Unions.Ids>? Media { get; set; } = [];
}