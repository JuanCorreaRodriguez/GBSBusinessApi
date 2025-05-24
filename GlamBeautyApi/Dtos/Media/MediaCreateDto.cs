using System.ComponentModel.DataAnnotations;

namespace GBSApi.Dtos.Media;

public class MediaCreateDto
{
    [Required(ErrorMessage = "Media name is required")]
    [MaxLength(100, ErrorMessage = "Maximum Name length is 50")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Media reference is required")]
    [MaxLength(500)]
    public string Reference { get; set; } = string.Empty;

    [MaxLength(500)] public string? Metadata { get; set; } = string.Empty;
}