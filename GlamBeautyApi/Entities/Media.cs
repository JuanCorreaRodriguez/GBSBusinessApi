using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlamBeautyApi.Entities;

[Table("Media")]
public class Media
{
    [Key] [Column("media_id")] public Guid MediaId { get; set; }

    [Column("reference")] [MaxLength(200)] public string Reference { get; set; } = string.Empty;

    [Column("metadata")] [MaxLength(500)] public string Metadata { get; set; } = string.Empty;

    public List<Brand> Brand { get; set; } = [];
}