using GlamBeautyApi.Dtos.Course;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Util;

namespace GlamBeautyApi.Interfaces.Course;

public interface ICourseRepository
{
    Task<IEnumerable<CourseDto>> GetCoursesAsync(QueryCourse query);
    Task<CourseDto?> GetCourseAsync(string id);
    Task<Entities.Course?> GetEntityCourseAsync(string id);
    Task<bool> ExistCourseAsync(string id);
    Task<IEnumerable<Entities.Course>?> GetCoursesByUserAsync(string id);
    Task<Entities.Course> PostCourseAsync(string categoryId, CourseCreateDto course, List<AppUser> appUsers);
    Task<Entities.Course?> PutCourseAsync(string id, CourseUpdateDto dto, List<AppUser> appUsers);
    Task<string?> DeleteAsync(string id);
}