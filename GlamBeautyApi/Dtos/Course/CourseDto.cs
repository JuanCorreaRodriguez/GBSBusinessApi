using System.ComponentModel.DataAnnotations;
using GBSApi.Dtos.AppUser;
using GBSApi.Dtos.Category;
using GBSApi.Dtos.Media;
using GBSApi.Util;

namespace GBSApi.Dtos.Course;

public class CourseDto
{
    // public List<UserDto> Users { get; set; } = [];

    // public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "Course Id is required")]
    public Guid CourseId { get; set; }

    [Required(ErrorMessage = "Course name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string CourseName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public string CourseDesc { get; set; } = string.Empty;

    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Course start_at is required")]
    public DateTime StartAt { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Course end_at is required")]
    public DateTime EndAt { get; set; } = DateTime.UtcNow;

    [MaxLength(50)] public string Ranking { get; set; } = string.Empty;

    [Required(ErrorMessage = "Course price is required")]
    [Range(1, 100000, ErrorMessage = "Course price must be between 1 and 1000.")]
    public decimal Price { get; set; } = decimal.Zero;

    [Required(ErrorMessage = "Capacity is required")]
    [Range(1, 100, ErrorMessage = "Capacity must be between 1 and 100.")]
    public int Capacity { get; set; } = 0;

    public CategoryMinDto Category { get; set; }

    public List<AppUserCourseMinDto> AppUsers { get; set; } = [];

    public List<MediaMinInnerDto> Media { get; set; } = [];

    public string Availability { get; set; } = CourseAvailabilityEnum.ComingSoon.ToString();

    public string Status { get; set; } = CourseStatusEnum.Open.ToString();
}