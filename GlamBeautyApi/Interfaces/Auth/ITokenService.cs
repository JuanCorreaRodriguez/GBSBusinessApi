using GlamBeautyApi.Entities;

namespace GlamBeautyApi.Interfaces.Auth;

public interface ITokenService
{
    string CreateToken(AppUser user);
}