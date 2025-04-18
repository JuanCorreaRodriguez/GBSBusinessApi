﻿using GlamBeautyApi.Util;

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

    public List<CourseAppUserIds>? AppUser { get; set; }

    public string? Availability { get; set; } = CourseAvailabilityEnum.ComingSoon.ToString();

    public string? Status { get; set; } = CourseStatusEnum.Open.ToString();
}