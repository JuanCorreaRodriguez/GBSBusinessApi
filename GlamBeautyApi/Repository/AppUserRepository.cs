using GBSApi.Connections;
using GBSApi.Dtos.AppUser;
using GBSApi.Dtos.Course;
using GBSApi.Entities;
using GBSApi.Interfaces.User;
using Microsoft.EntityFrameworkCore;

namespace GBSApi.Repository;

public class AppUserRepository : IAppUserRepository
{
    private readonly PostgreDbContext _context;

    public AppUserRepository(PostgreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AppUserMinDto>> GetAllUsers()
    {
        return await _context.AppUsers
            .Select(o => new AppUserMinDto
            {
                Id = o.Id,
                UserName = o.UserName!,
                UserDesc = o.UserDesc,
                Email = o.Email!,
                PhoneNumber = o.PhoneNumber!,
                CreateAt = o.CreateAt,
                Courses = o.Course.Select(c => new CourseMinDto
                {
                    CourseName = c.CourseName,
                    CourseId = c.CourseId,
                    CourseDesc = c.CourseDesc,
                    StartAt = c.StartAt,
                    EndAt = c.EndAt
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<AppUser?> GetUserEntityById(string id)
    {
        var user = await _context.AppUsers.FirstAsync(o => o.Id == id);

        return user;
    }

    public async Task<AppUserMinDto?> GetUserById(string id)
    {
        // var guid = new Guid(id);
        return await _context.Users
            .Select(o => new AppUserMinDto
            {
                Id = o.Id,
                UserName = o.UserName!,
                UserDesc = o.UserDesc,
                Email = o.Email!,
                PhoneNumber = o.PhoneNumber!,
                CreateAt = o.CreateAt,
                Courses = o.Course.Select(c => new CourseMinDto
                {
                    CourseName = c.CourseName,
                    CourseId = c.CourseId,
                    CourseDesc = c.CourseDesc,
                    StartAt = c.StartAt,
                    EndAt = c.EndAt
                }).ToList()
            })
            .FirstOrDefaultAsync(o => o.Id == id);
        // return await _context.Users.FindAsync(guid);
    }

    public async Task<string?> DeleteAsync(string id)
    {
        var user = await FirstAppUserAsync(id);
        if (user == null) return null;


        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return id;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<AppUser?> UpdateAsync(string id, AppUserUpdateDto appUser)
    {
        return await _context.Users.FirstOrDefaultAsync(v => v.Id.ToString() == id);
    }

    public async Task<AppUser?> FirstAppUserAsync(string id)
    {
        return await _context.AppUsers.FirstOrDefaultAsync(v => v.Id.ToString() == id);
    }

    public async Task<AppUser?> GetUserAllById(string id)
    {
        var user = await _context.AppUsers
            .Include(o => o.Course)
            .FirstAsync(o => o.Id == id);

        return user;

        // var guid = new Guid(id);
        // return await _context.Users
        //     .Select(o => new AppUser
        //     {
        //         Id = o.Id,
        //         UserName = o.UserName!,
        //         Email = o.Email!,
        //         PhoneNumber = o.PhoneNumber!,
        //         CreateAt = o.CreateAt,
        //         Course = o.Course.Select(c => new Course
        //         {
        //             CourseName = c.CourseName,
        //             CourseId = c.CourseId,
        //             CourseDesc = c.CourseDesc,
        //             StartAt = c.StartAt,
        //             EndAt = c.EndAt
        //         }).ToList()
        //     })
        //     .FirstOrDefaultAsync(o => o.Id == id);
    }
}