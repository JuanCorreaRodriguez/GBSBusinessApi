using GBSApi.Entities;

namespace GBSApi.Interfaces.Auth;

public interface ITokenService
{
    string CreateToken(AppUser user);
}