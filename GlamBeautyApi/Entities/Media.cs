using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Entities;

[Table("Media")]
[Index(nameof(MediaId), IsUnique = true)]
public class Media
{
    [Key] [Column("media_id")] public Guid MediaId { get; set; }

    [Column("name")] [MaxLength(50)] public string Name { get; set; } = string.Empty;
    
    [Column("reference")] [MaxLength(200)] public string Reference { get; set; } = string.Empty;

    [Column("metadata")] [MaxLength(800)] public string Metadata { get; set; } = string.Empty;

    public List<Brand> Brand { get; set; } = [];

    public List<Category> Category { get; set; } = [];

    public List<Course> Course { get; set; } = [];
}