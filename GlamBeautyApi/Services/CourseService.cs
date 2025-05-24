using System.Text.Json;
using GBSApi.Dtos.Course;
using GBSApi.Entities;
using GBSApi.Interfaces.Category;
using GBSApi.Interfaces.Course;
using GBSApi.Interfaces.Media;
using GBSApi.Interfaces.User;
using GBSApi.Mappers;
using GBSApi.Queries;

namespace GBSApi.Services;

public class CourseService : ICourseService
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IMediaRepository _mediaRepository;

    public CourseService(
        ICourseRepository courseRepository,
        ICategoryRepository categoryRepository,
        IAppUserRepository appUserRepository,
        IMediaRepository mediaRepository
    )
    {
        _courseRepository = courseRepository;
        _categoryRepository = categoryRepository;
        _appUserRepository = appUserRepository;
        _mediaRepository = mediaRepository;
    }

    public async Task<CourseDto?> GetCourse(string id)
    {
        return await _courseRepository.GetCourseAsync(id);
    }

    public async Task<CourseDto> CreateCourse(string categoryId, CourseCreateDto course)
    {
        var users = course.AppUser;
        List<AppUser> appUsers = [];

        if (users != null)
            appUsers = await GetUsersFromList(users);

        var c = await _courseRepository.PostCourseAsync(categoryId, course, appUsers);
        return c.ModelToDto();
    }

    public async Task<List<AppUser>> GetUsersFromList(List<CourseAppUserIds> users)
    {
        List<AppUser> appUsers = [];
        foreach (var user in users)
        {
            var userEntity = await _appUserRepository.GetUserEntityById(user.Id);
            if (userEntity != null) appUsers.Add(userEntity);
        }

        return appUsers;
    }

    public async Task<bool> CategoryExists(string id)
    {
        return await _categoryRepository.ExistCategoryAsync(id);
    }

    public async Task<CourseDto?> UpdateCourse(string id, CourseUpdateDto course)
    {
        var existsCourse = await _courseRepository.ExistCourseAsync(id);
        if (!existsCourse) return null;

        if (course.Category.ToString() != null && course.Category.ToString() != "")
        {
            var existsCategory = await CategoryExists(course.Category.ToString()!);
            if (!existsCategory) return null;
        }

        List<AppUser> appUsers = [];
        List<Media> media = [];

        if (course.AppUser != null)
            appUsers = await GetUsersFromList(course.AppUser);

        if (course.Media != null)
            media = await _mediaRepository.GetMediaFromList(course.Media);

        Console.WriteLine($"{JsonSerializer.Serialize(course.Media)}");
        Console.WriteLine($"{JsonSerializer.Serialize(media)}");
        var courseUpdated = await _courseRepository.PutCourseAsync(id, course, appUsers, media);
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