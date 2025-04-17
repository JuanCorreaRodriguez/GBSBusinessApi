using GlamBeautyApi.Dtos.AppUser;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.User;
using GlamBeautyApi.Mappers;

namespace GlamBeautyApi.Services;

public class AppUserService : IAppUserService
{
    private readonly IAppUserRepository _appUserRepository;

    public AppUserService(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public async Task<IEnumerable<AppUserMinDto>> GetAllUsers()
    {
        var users = await _appUserRepository.GetAllUsers();
        // var usersDto = users.Select(v => v.ModelToDto());
        return users;
    }

    public async Task<AppUserMinDto?> GetUser(string id)
    {
        return await _appUserRepository.GetUserById(id);
    }

    public async Task<AppUserMinDto?> UpdateUser(string id, AppUserUpdateDto dto)
    {
        var userModel = await _appUserRepository.GetUserAllById(id);

        if (userModel == null) return null;

        if (!string.IsNullOrEmpty(dto.UserName)) userModel.UserName = dto.UserName;

        if (!string.IsNullOrEmpty(dto.UserDesc)) userModel.UserDesc = dto.UserDesc;

        if (!string.IsNullOrEmpty(dto.Ranking)) userModel.Ranking = dto.Ranking;

        if (dto.Courses != null)
        {
            List<Course> courses = [];
            foreach (var course in dto.Courses) courses.Add(course.DtoToModel());

            userModel.Course = courses;
        }

        await _appUserRepository.SaveChangesAsync();

        return userModel.ModelToDtoMin();
    }

    public async Task<string?> DeleteUser(string id)
    {
        return await _appUserRepository.DeleteAsync(id);
    }
}