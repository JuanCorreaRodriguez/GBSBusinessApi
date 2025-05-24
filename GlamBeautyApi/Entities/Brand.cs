using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBSApi.Entities;

[Table("Brands")]
public class Brand
{
    [Key] [Column("brand_id")] public Guid BrandId { get; set; }

    [Column("name")] [MaxLength(50)] public string Name { get; set; } = string.Empty;

    [Column("description")]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Column("ranking")] [MaxLength(50)] public string Ranking { get; set; } = string.Empty;

    public List<Media> Media { get; set; } = [];
}