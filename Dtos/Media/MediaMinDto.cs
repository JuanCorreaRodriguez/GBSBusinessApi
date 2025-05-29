using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.Brand;
using GBSApi.Dtos.Category;

namespace GBSApi.Dtos.Media;

public class MediaMinDto
{
    [MaxLength(50)] public Guid? MediaId { get; set; }

    [MaxLength(50)] public string Name { get; set; }

    [MaxLength(500)] public string? Reference { get; set; } = string.Empty;

    [MaxLength(500)] public string? Metadata { get; set; } = string.Empty;

    public List<BrandMinInnerDto>? Brand { get; set; } = [];

    public List<CategoryMinDto>? Category { get; set; } = [];
}

public class MediaMinInnerDto
{
    [MaxLength(50)] public string Name { get; set; }

    [MaxLength(500)] public string? Reference { get; set; } = string.Empty;

    [MaxLength(500)] public string? Metadata { get; set; } = string.Empty;
}