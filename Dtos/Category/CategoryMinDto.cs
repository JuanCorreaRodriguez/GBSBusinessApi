using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.Media;

namespace GBSApi.Dtos.Category;

public class CategoryMinDto
{
    [MaxLength(50)] public Guid CategoryId { get; set; }

    [MaxLength(50)] public required string Name { get; set; }

    [MaxLength(1000)] public string Desc { get; set; } = string.Empty;

    [MaxLength(200)] public string Type { get; set; } = string.Empty;

    public List<MediaMinInnerDto>? Media { get; set; } = [];
}