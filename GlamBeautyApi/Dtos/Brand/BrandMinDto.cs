﻿using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Brand;

public class BrandMinDto
{
    [MaxLength(50)] public Guid? BrandId { get; set; }

    [MaxLength(50)] public string? Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

    [MaxLength(50)] public string? Ranking { get; set; } = string.Empty;
}