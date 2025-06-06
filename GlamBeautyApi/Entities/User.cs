using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBSApi.Entities;

[Table("Users")]
public class User
{
    [Key] [Column("user_id")] public Guid UserId { get; set; }

    [MaxLength(50)] [Column("user_name")] public string UserName { get; set; } = string.Empty;

    [MaxLength(200)] [Column("user_desc")] public string UserDesc { get; set; } = string.Empty;

    [MaxLength(50)] [Column("ranking")] public string? Ranking { get; set; } = string.Empty;

    [Column("create_at")] public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    public List<Course> Course { get; } = [];
    public List<UserCourse> UserCourses { get; } = [];
}