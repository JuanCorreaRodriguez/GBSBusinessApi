using GBSApi.Dtos.AppUser;
using GBSApi.Dtos.Course;
using GBSApi.Entities;

namespace GBSApi.Mappers;

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
            StartAt = course.StartAt,
            Availability = course.Availability,
            Status = course.Status
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
            CourseName = courseDto.CourseName,
            Availability = courseDto.Availability,
            Status = courseDto.Status
            // Users = courseDto.Users.Select(v => v.DtoToModel()).ToList()
        };
    }

    public static Course CreateDtoToModel(
        this CourseCreateDto courseDto, string categoryId, List<AppUser> appUsers
    )
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
            CategoryId = Guid.Parse(categoryId),
            AppUser = appUsers,
            Availability = courseDto.Availability,
            Status = courseDto.Status
            // Users = courseDto.Users.Select(v => v.DtoToModel()).ToList()
        };
    }
}