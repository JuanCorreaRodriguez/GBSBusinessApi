using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Course;

public class CourseMinDto
{
    [Required(ErrorMessage = "Course Id is required")]
    public Guid CourseId { get; set; }

    [Required(ErrorMessage = "Course name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string CourseName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
    public string CourseDesc { get; set; } = string.Empty;

    [Required(ErrorMessage = "Course start_at is required")]
    public DateTime StartAt { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Course end_at is required")]
    public DateTime EndAt { get; set; } = DateTime.UtcNow;
}