using System.ComponentModel.DataAnnotations;
using GlamBeautyApi.Dtos.Brand;

namespace GlamBeautyApi.Dtos.Media;

public class MediaDto
{
    [MaxLength(50)] public Guid MediaId { get; set; }

    [MaxLength(500)] public string Reference { get; set; } = string.Empty;

    [MaxLength(500)] public string Metadata { get; set; } = string.Empty;

    public List<BrandDto>? Brand { get; set; } = [];
}