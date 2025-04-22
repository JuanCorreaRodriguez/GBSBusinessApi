using GlamBeautyApi.Connections;
using GlamBeautyApi.Dtos.AppUser;
using GlamBeautyApi.Dtos.Category;
using GlamBeautyApi.Dtos.Course;
using GlamBeautyApi.Dtos.Media;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Course;
using GlamBeautyApi.Mappers;
using GlamBeautyApi.Queries;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly PostgreDbContext _context;

    public CourseRepository(PostgreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CourseDto>> GetCoursesAsync(QueryCourse query)
    {
        var courses = _context.Courses
            .Select(course => new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseDesc = course.CourseDesc,
                CreateAt = course.CreateAt,
                StartAt = course.StartAt,
                EndAt = course.EndAt,
                Price = course.Price,
                Ranking = course.Ranking,
                Capacity = course.Capacity,
                Category = new CategoryMinDto
                {
                    Name = course.Category.Name,
                    CategoryId = course.Category.CategoryId,
                    Desc = course.Category.Description
                },
                AppUsers = course.AppUser.Select(o => new AppUserCourseMinDto
                {
                    Id = o.Id,
                    Email = o.Email!,
                    UserName = o.UserName!,
                    Ranking = o.Ranking,
                    PhoneNumber = o.PhoneNumber!,
                    UserDesc = o.UserDesc!
                }).ToList(),
                Media = course.Media.Select(o => new MediaMinInnerDto
                {
                    Metadata = o.Metadata,
                    Reference = o.Reference
                }).ToList()
            })
            // .Include(o => o.Category)
            // .Include(o => o.AppUser)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Category))
            courses = courses.Where(o => o.Category.Name.Contains(query.Category));

        if (!string.IsNullOrWhiteSpace(query.Price.ToString()))
            courses = courses.Where(o => o.Price >= query.Price);

        if (!string.IsNullOrWhiteSpace(query.SortBy))
            if (query.SortBy.Equals("CourseName", StringComparison.OrdinalIgnoreCase))
                courses = query.IsDescending
                    ? courses.OrderByDescending(o => o.CourseName)
                    : courses.OrderBy(o => o.CourseName);

        var skipNumber = (query.PageNumber - 1) * query.PageSize;
        return await courses.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<CourseDto?> GetCourseAsync(string id)
    {
        var course = await _context.Courses
            .Select(course => new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseDesc = course.CourseDesc,
                CreateAt = course.CreateAt,
                StartAt = course.StartAt,
                EndAt = course.EndAt,
                Price = course.Price,
                Ranking = course.Ranking,
                Capacity = course.Capacity,
                Category = new CategoryMinDto
                {
                    Name = course.Category.Name,
                    CategoryId = course.Category.CategoryId,
                    Desc = course.Category.Description
                },
                AppUsers = course.AppUser.Select(o => new AppUserCourseMinDto
                {
                    Id = o.Id,
                    Email = o.Email!,
                    UserName = o.UserName!,
                    Ranking = o.Ranking,
                    PhoneNumber = o.PhoneNumber!,
                    UserDesc = o.UserDesc!
                }).ToList(),
                Media = course.Media.Select(o => new MediaMinInnerDto
                {
                    Metadata = o.Metadata,
                    Reference = o.Reference
                }).ToList()
            })
            .FirstOrDefaultAsync(o => o.CourseId == Guid.Parse(id));

        return course;
    }

    public async Task<Course?> GetEntityCourseAsync(string id)
    {
        return await _context.Courses.FirstAsync(o => o.CourseId == Guid.Parse(id));
    }

    public Task<bool> ExistCourseAsync(string id)
    {
        return _context.Courses.AnyAsync(o => o.CourseId == Guid.Parse(id));
    }

    public async Task<IEnumerable<Course>?> GetCoursesByUserAsync(string id)
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> PostCourseAsync(string categoryId, CourseCreateDto course, List<AppUser> appUsers)
    {
        var c = await _context.Courses.AddAsync(course.CreateDtoToModel(categoryId, appUsers));
        await _context.SaveChangesAsync();
        return c.Entity;
    }

    public async Task<Course?> PutCourseAsync(string id, CourseUpdateDto dto, List<AppUser> appUsers,
        List<Media> medias)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(o => o.CourseId == Guid.Parse(id));
        if (course == null) return null;

        if (!string.IsNullOrEmpty(dto.CourseName)) course.CourseName = dto.CourseName;
        if (!string.IsNullOrEmpty(dto.CourseDesc)) course.CourseDesc = dto.CourseDesc;
        if (!string.IsNullOrEmpty(dto.Ranking)) course.Ranking = dto.Ranking;
        if (dto.Capacity is > 0) course.Capacity = (int)dto.Capacity;
        if (dto.Price is > 0) course.Price = (decimal)dto.Price;
        if (dto.StartAt != null) course.StartAt = (DateTime)dto.StartAt;
        if (dto.EndAt != null) course.EndAt = (DateTime)dto.EndAt;
        if (dto.Category != null) course.CategoryId = (Guid)dto.Category;
        if (!string.IsNullOrEmpty(dto.Availability)) course.Availability = dto.Availability;
        if (!string.IsNullOrEmpty(dto.Status)) course.Status = dto.Status;

        if (appUsers.Count > 0)
            foreach (var appUser in appUsers)
                course.AppUser.Add(appUser);

        if (medias.Count > 0)
            foreach (var media in medias)
                course.Media.Add(media);

        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<string?> DeleteAsync(string id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(o => o.CourseId == Guid.Parse(id));

        if (course == null) return null;
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return id;
    }
}