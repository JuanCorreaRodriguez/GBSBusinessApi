using GBSApi.Dtos.Course;
using GBSApi.Entities;
using GBSApi.Queries;

namespace GBSApi.Interfaces.Course;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllCourses(QueryCourse query);
    Task<CourseDto?> GetCourse(string id);
    Task<CourseDto> CreateCourse(string categoryId, CourseCreateDto course);
    Task<bool> CategoryExists(string id);
    Task<CourseDto?> UpdateCourse(string id, CourseUpdateDto course);
    Task<string?> DeleteAsync(string id);
    Task<List<AppUser>> GetUsersFromList(List<CourseAppUserIds> users);
}