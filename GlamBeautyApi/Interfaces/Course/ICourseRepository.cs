using GlamBeautyApi.Dtos.Course;
using GlamBeautyApi.Util;

namespace GlamBeautyApi.Interfaces.Course;

public interface ICourseRepository
{
    Task<IEnumerable<CourseDto>> GetCoursesAsync(QueryCourse query);
    Task<CourseDto?> GetCourseAsync(string id);
    Task<bool> ExistCourseAsync(string id);
    Task<IEnumerable<Entities.Course>?> GetCoursesByUserAsync(string id);
    Task<Entities.Course> PostCourseAsync(string categoryId, CourseCreateDto course);
    Task<Entities.Course?> PutCourseAsync(string id, CourseUpdateDto dto);
    Task<string?> DeleteAsync(string id);
}