using GlamBeautyApi.Dtos.AppUser;
using GlamBeautyApi.Dtos.User;

namespace GlamBeautyApi.Interfaces.User;

public interface IAppUserService
{
    Task<IEnumerable<AppUserMinDto>> GetAllUsers();
    Task<AppUserMinDto?> GetUser(string id);
    Task<AppUserMinDto?> UpdateUser(string id, AppUserUpdateDto appUser);
    Task<string?> DeleteUser(string id);
}