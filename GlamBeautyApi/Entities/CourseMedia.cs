using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBSApi.Entities;

public class CourseMedia
{
    [Column("course_id")] [MaxLength(50)] public Guid CourseId { get; set; }
    [Column("media_id")] [MaxLength(50)] public Guid MediaId { get; set; }
}