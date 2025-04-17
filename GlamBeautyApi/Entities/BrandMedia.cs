using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlamBeautyApi.Entities;

public class BrandMedia
{
    [Column("brand_id")] [MaxLength(50)] public Guid BrandId { get; set; }

    [Column("media_id")] [MaxLength(50)] public Guid MediaId { get; set; }
}