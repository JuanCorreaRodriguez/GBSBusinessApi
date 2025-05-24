using GBSApi.Dtos.Course;
using Microsoft.AspNetCore.Identity;

namespace GBSApi.Dtos.AppUser;

public class AppUserDto : IdentityUser
{
    public string UserDesc { get; set; } = string.Empty;

    public DateTime CreateAt { get; set; } = DateTime.Now;

    public string? Ranking { get; set; } = string.Empty;

    public List<CourseDto> Courses { get; set; } = [];
}