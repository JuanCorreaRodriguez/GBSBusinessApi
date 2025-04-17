﻿using System.ComponentModel.DataAnnotations;
using GlamBeautyApi.Util;

namespace GlamBeautyApi.Dtos.Course;

public class CourseAppUserIds
{
    public string Id { get; set; } = null!;
}

public class CourseCreateDto
{
    [MaxLength(50, ErrorMessage = "Course name cannot be longer than 50 characters.")]
    public string CourseName { get; set; } = string.Empty;

    public string CourseDesc { get; set; } = string.Empty;

    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    public DateTime StartAt { get; set; } = DateTime.UtcNow;

    public DateTime EndAt { get; set; } = DateTime.UtcNow;

    public string Ranking { get; set; } = string.Empty;

    public decimal Price { get; set; } = decimal.Zero;

    public int Capacity { get; set; } = 0;

    public List<CourseAppUserIds>? AppUser { get; set; } = [];

    public string Availability { get; set; } = CourseAvailabilityEnum.ComingSoon.ToString();

    public string Status { get; set; } = CourseStatusEnum.Open.ToString();
}