using GBSApi.Dtos.Course;

namespace GBSApi.Dtos.AppUser;

public class AppUserMinDto
{
    public string Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string UserDesc { get; set; } = string.Empty;

    public DateTime CreateAt { get; set; } = DateTime.Now;

    public string? Ranking { get; set; } = string.Empty;

    public List<CourseMinDto> Courses { get; set; } = [];
}

public class AppUserCourseMinDto
{
    public string Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string UserDesc { get; set; } = string.Empty;

    public string? Ranking { get; set; } = string.Empty;
}