﻿using GlamBeautyApi.Dtos.AppUser;
using GlamBeautyApi.Dtos.Course;
using GlamBeautyApi.Dtos.User;
using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Mappers;

public static class AppUserMapper
{
    public static AppUserDto ModelToDto(this AppUser user)
    {
        return new AppUserDto
        {
            Id = user.Id,
            Email = user.Email,
            NormalizedEmail = user.NormalizedEmail,
            NormalizedUserName = user.NormalizedUserName,
            CreateAt = user.CreateAt,
            UserDesc = user.UserDesc,
            UserName = user.UserName,
            Ranking = user.Ranking!,
            Courses = CourseToDto(user.Course)
        };
    }

    private static List<CourseDto> CourseToDto(List<Course> courses)
    {
        var coursesDto = new List<CourseDto>();
        foreach (var course in courses)
            coursesDto.Add(new CourseDto
            {
                CourseDesc = course.CourseDesc,
                CourseId = course.CourseId,
                CourseName = course.CourseName
            });
        return coursesDto;

        var coursesDto2 = courses.Select(course => new CourseDto
        {
            Capacity = course.Capacity,
            CreateAt = course.CreateAt,
            Ranking = course.Ranking,
            // Category = course.Category,
            StartAt = course.StartAt,
            EndAt = course.EndAt,
            Price = course.Price,
            CourseDesc = course.CourseDesc,
            CourseId = course.CourseId,
            CourseName = course.CourseName
        }).ToList();

        return coursesDto;
    }

    public static AppUser DtoToModel(this AppUserDto dto)
    {
        return new AppUser
        {
            Id = dto.Id,
            Email = dto.Email,
            NormalizedEmail = dto.NormalizedEmail,
            NormalizedUserName = dto.NormalizedUserName,
            CreateAt = dto.CreateAt,
            UserDesc = dto.UserDesc,
            UserName = dto.UserName,
            Ranking = dto.Ranking!
        };
    }

    public static AppUserMinDto DtoToDtoMin(this AppUserDto dto)
    {
        return new AppUserMinDto
        {
            Id = dto.Id,
            Email = dto.Email!,
            CreateAt = dto.CreateAt,
            UserDesc = dto.UserDesc,
            UserName = dto.UserName!,
            Ranking = dto.Ranking!
        };
    }

    public static AppUserMinDto ModelToDtoMin(this AppUser dto)
    {
        return new AppUserMinDto
        {
            Id = dto.Id,
            Email = dto.Email!,
            CreateAt = dto.CreateAt,
            UserDesc = dto.UserDesc,
            UserName = dto.UserName!,
            Ranking = dto.Ranking!
        };
    }

    public static AppUser CreateDtoToModel(this AppUserCreateDto dto)
    {
        return new AppUser
        {
            Id = dto.Id,
            Email = dto.Email,
            NormalizedEmail = dto.NormalizedEmail,
            NormalizedUserName = dto.NormalizedUserName,
            CreateAt = dto.CreateAt,
            UserDesc = dto.UserDesc,
            UserName = dto.UserName,
            Ranking = dto.Ranking!
        };
    }
}