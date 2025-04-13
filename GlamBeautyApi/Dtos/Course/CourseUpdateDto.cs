namespace GlamBeautyApi.Dtos.Course;

public class CourseUpdateDto
{
    public Guid? Category { get; set; }

    public string? CourseName { get; set; }

    public string? CourseDesc { get; set; }

    public DateTime? StartAt { get; set; }

    public DateTime? EndAt { get; set; }

    public string? Ranking { get; set; }

    public decimal? Price { get; set; }

    public int? Capacity { get; set; }
}