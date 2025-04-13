using System.ComponentModel.DataAnnotations.Schema;

namespace GlamBeautyApi.Entities;

[Table("usercourse")]
public class UserCourse
{
    [Column("user_id")] public string UserId { get; set; }

    // public AppUser AppUser { get; set; } = null!;
    [Column("course_id")] public Guid CourseId { get; set; }
    // public Course Course { get; set; } = null!;
}