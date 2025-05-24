using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.Brand;

namespace GBSApi.Dtos.Media;

public class MediaDto
{
    [MaxLength(50)] public Guid MediaId { get; set; }

    [MaxLength(50)] public string Name { get; set; }

    [MaxLength(500)] public string Reference { get; set; } = string.Empty;

    [MaxLength(500)] public string Metadata { get; set; } = string.Empty;

    public List<BrandDto>? Brand { get; set; } = [];
}