using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.Course;

namespace GBSApi.Dtos.AppUser;

public class AppUserUpdateDto
{
    [MaxLength(100)] public string? UserName { get; set; } = null!;

    [MaxLength(200)] public string? UserDesc { get; set; } = null!;

    [MaxLength(50)] public string? PhoneNumber { get; set; } = null!;

    [MaxLength(50)] public string? Ranking { get; set; } = null!;

    public List<CourseDto>? Courses { get; set; } = null!;
}