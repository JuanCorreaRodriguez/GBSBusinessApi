using System.ComponentModel.DataAnnotations;
using GlamBeautyApi.Dtos.Unions;

namespace GlamBeautyApi.Dtos.Media;

public class MediaUpdateDto
{
    [MaxLength(50)] public string Name { get; set; }

    [MaxLength(500)] public string? Reference { get; set; } = string.Empty;

    [MaxLength(500)] public string? Metadata { get; set; } = string.Empty;

    public List<Ids>? Brand { get; set; } = [];
}