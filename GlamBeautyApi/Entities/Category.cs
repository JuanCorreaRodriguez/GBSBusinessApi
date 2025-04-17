using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Entities;

[Index(nameof(CategoryId), IsUnique = true)]
public class Category
{
    [Key] [Column("category_id")] public Guid CategoryId { get; set; }

    [MaxLength(50)]
    [Column("category_name")]
    public required string CategoryName { get; set; }

    [MaxLength(250)]
    [Column("category_desc")]
    public string CategoryDesc { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("category_type")]
    public string CategoryType { get; set; } = string.Empty;

    [Column("parent_id")] public Guid? ParentId { get; set; }

    public Category? Parent { get; set; }

    public ICollection<Category> SubCategories { get; set; } = [];

    // public ICollection<Course> Courses { get; set; }
}