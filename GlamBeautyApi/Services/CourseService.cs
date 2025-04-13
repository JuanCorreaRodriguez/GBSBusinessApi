using GlamBeautyApi.Dtos.Course;
using GlamBeautyApi.Interfaces.Category;
using GlamBeautyApi.Interfaces.Course;
using GlamBeautyApi.Mappers;
using GlamBeautyApi.Util;

namespace GlamBeautyApi.Services;

public class CourseService : ICourseService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICourseRepository _courseRepository;

    public CourseService(
        ICourseRepository courseRepository,
        ICategoryRepository categoryRepository
    )
    {
        _courseRepository = courseRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<CourseDto?> GetCourse(string id)
    {
        return await _courseRepository.GetCourseAsync(id);
    }

    public async Task<CourseDto> CreateCourse(string categoryId, CourseCreateDto course)
    {
        var c = await _courseRepository.PostCourseAsync(categoryId, course);
        return c.ModelToDto();
    }

    public async Task<bool> CategoryExists(string id)
    {
        return await _categoryRepository.ExistCategoryAsync(id);
    }

    public async Task<CourseDto?> UpdateCourse(string id, CourseUpdateDto course)
    {
        var existsCourse = await _courseRepository.ExistCourseAsync(id);

        if (course.Category.ToString() != null)
        {
            var existsCategory = await CategoryExists(course.Category.ToString()!);
            if (!existsCategory) return null;
        }

        if (!existsCourse) return null;

        var courseUpdated = await _courseRepository.PutCourseAsync(id, course);
        return courseUpdated?.ModelToDto();
    }

    public async Task<string?> DeleteAsync(string id)
    {
        var deleted = await _courseRepository.DeleteAsync(id);
        return deleted;
    }

    public async Task<IEnumerable<CourseDto>> GetAllCourses(QueryCourse query)
    {
        return await _courseRepository.GetCoursesAsync(query);
    }
}