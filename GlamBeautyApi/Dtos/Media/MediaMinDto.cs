using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Media;

public class MediaMinDto
{
    [MaxLength(50)] public Guid? MediaId { get; set; }

    [MaxLength(500)] public string? Reference { get; set; } = string.Empty;

    [MaxLength(500)] public string? Metadata { get; set; } = string.Empty;
}