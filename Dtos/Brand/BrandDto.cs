using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.Media;

namespace GBSApi.Dtos.Brand;

public class BrandDto
{
    [MaxLength(50)] public Guid BrandId { get; set; }

    [MaxLength(50)] public string Name { get; set; } = string.Empty;

    [MaxLength(500)] public string Description { get; set; } = string.Empty;

    [MaxLength(50)] public string Ranking { get; set; } = string.Empty;

    public List<MediaDto>? Media { get; set; } = [];
}