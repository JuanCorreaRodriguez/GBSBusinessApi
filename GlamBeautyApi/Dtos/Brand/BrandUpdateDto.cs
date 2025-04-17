using System.ComponentModel.DataAnnotations;
using GlamBeautyApi.Dtos.Unions;

namespace GlamBeautyApi.Dtos.Brand;

public class BrandUpdateDto
{
    [MaxLength(50)] public string? Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

    [MaxLength(50)] public string? Ranking { get; set; } = string.Empty;

    public List<Ids>? Media { get; set; } = [];
}