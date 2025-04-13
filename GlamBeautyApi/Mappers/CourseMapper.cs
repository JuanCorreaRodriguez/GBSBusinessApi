using GlamBeautyApi.Dtos.AppUser;
using GlamBeautyApi.Dtos.Course;
using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Mappers;

public static class CourseMapper
{
    public static CourseDto ModelToDto(this Course course)
    {
        return new CourseDto
        {
            CourseId = course.CourseId,
            CourseName = course.CourseName,
            Price = course.Price,
            Ranking = course.Ranking,
            Capacity = course.Capacity,
            CreateAt = course.CreateAt,
            CourseDesc = course.CourseDesc,
            EndAt = course.EndAt,
            StartAt = course.StartAt
            // Category = course.Category,
            // AppUsers = AppUsersToDto(course.AppUser)
        };
    }

    private static List<AppUserCourseMinDto> AppUsersToDto(List<AppUser> appUser)
    {
        return appUser.Select(user => new AppUserCourseMinDto
            {
                UserName = user.UserName!,
                UserDesc = user.UserDesc,
                Ranking = user.Ranking,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!
            }
        ).ToList();
    }

    public static Course DtoToModel(this CourseDto courseDto)
    {
        return new Course
        {
            Price = courseDto.Price,
            Ranking = courseDto.Ranking,
            CourseDesc = courseDto.CourseDesc,
            CreateAt = courseDto.CreateAt,
            EndAt = courseDto.EndAt,
            StartAt = courseDto.StartAt,
            Capacity = courseDto.Capacity,
            CourseName = courseDto.CourseName
            // Users = courseDto.Users.Select(v => v.DtoToModel()).ToList()
        };
    }

    public static Course CreateDtoToModel(this CourseCreateDto courseDto, string categoryId)
    {
        return new Course
        {
            Price = courseDto.Price,
            Ranking = courseDto.Ranking,
            CourseDesc = courseDto.CourseDesc,
            CreateAt = courseDto.CreateAt,
            EndAt = courseDto.EndAt,
            StartAt = courseDto.StartAt,
            Capacity = courseDto.Capacity,
            CourseName = courseDto.CourseName,
            CategoryId = Guid.Parse(categoryId)
            // Users = courseDto.Users.Select(v => v.DtoToModel()).ToList()
        };
    }
}