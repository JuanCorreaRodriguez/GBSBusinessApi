using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlamBeautyApi.Entities;

[Table("usercourse")]
public class UserCourse
{
    [Column("user_id")] [MaxLength(50)] public required string UserId { get; set; }

    // public AppUser AppUser { get; set; } = null!;
    [Column("course_id")] [MaxLength(50)] public Guid CourseId { get; set; }
    // public Course Course { get; set; } = null!;
}