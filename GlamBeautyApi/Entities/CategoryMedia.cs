using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlamBeautyApi.Entities;

public class CategoryMedia
{
    [Column("category_id")]
    [MaxLength(50)]
    public Guid CategoryId { get; set; }

    [Column("media_id")] [MaxLength(50)] public Guid MediaId { get; set; }
}