using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlamBeautyApi.Util;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Entities;

[Table("Courses")]
[Index(nameof(CourseId), IsUnique = true)]
public class Course
{
    [Key] [Column("course_id")] public Guid CourseId { get; set; }

    [MaxLength(50)]
    [Column("course_name")]
    public string CourseName { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("description")]
    public string CourseDesc { get; set; } = string.Empty;

    [Column("create_at")] public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    [Column("start_at")] public DateTime StartAt { get; set; } = DateTime.UtcNow;

    [Column("end_at")] public DateTime EndAt { get; set; } = DateTime.UtcNow;

    [MaxLength(50)] [Column("ranking")] public string Ranking { get; set; } = string.Empty;

    [Column("price")] public decimal Price { get; set; } = decimal.Zero;

    [Column("capacity")] public int Capacity { get; set; } = 0;

    [Column("category_id")] public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public List<AppUser> AppUser { get; set; } = [];

    public List<Media> Media { get; set; } = [];

    [Column("availability")]
    [MaxLength(50)]
    public string Availability { get; set; } = CourseAvailabilityEnum.ComingSoon.ToString();

    [Column("status")] [MaxLength(50)] public string Status { get; set; } = CourseStatusEnum.Open.ToString();


    // public List<UserCourse> UserCourses { get; } = [];
}