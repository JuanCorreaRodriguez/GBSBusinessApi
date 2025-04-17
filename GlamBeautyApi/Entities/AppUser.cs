using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Entities;

[Table("AspNetUsers")]
[Index(nameof(Id), IsUnique = true)]
public class AppUser : IdentityUser
{
    [MaxLength(200)] [Column("user_desc")] public string UserDesc { get; set; } = string.Empty;

    [MaxLength(50)] [Column("ranking")] public string? Ranking { get; set; } = string.Empty;

    [Column("create_at")] public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    public List<Course> Course { get; set; } = [];

    // public List<UserCourse> UserCourses { get; } = [];
}