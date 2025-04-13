using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlamBeautyApi.Entities;

public class MultimediaModel
{
    [Key] [Column("multimedia_id")] public int MediaId { get; set; }

    [Column("reference")] public string Reference { get; set; } = string.Empty;

    [Column("promo_id")] public string? PromoId { get; set; }

    [Column("product_id")] public string? ProductId { get; set; }

    [Column("course_id")] public string? CourseId { get; set; }
}