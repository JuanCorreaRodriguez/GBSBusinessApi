using GlamBeautyApi.Dtos.AppUser;
using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Interfaces.User;

public interface IAppUserRepository
{
    Task<IEnumerable<AppUserMinDto>> GetAllUsers();
    Task<AppUser?> FirstAppUserAsync(string id);
    Task<AppUser?> GetUserAllById(string id);
    Task<AppUserMinDto?> GetUserById(string id);
    Task<AppUser?> UpdateAsync(string id, AppUserUpdateDto appUser);
    Task<string?> DeleteAsync(string id);
    Task SaveChangesAsync();
}