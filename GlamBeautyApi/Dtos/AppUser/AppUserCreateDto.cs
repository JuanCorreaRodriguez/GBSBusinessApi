using Microsoft.AspNetCore.Identity;

namespace GlamBeautyApi.Dtos.User;

public class AppUserCreateDto : IdentityUser
{
    public string UserDesc { get; set; } = string.Empty;

    public string? Ranking { get; set; } = string.Empty;

    public DateTime CreateAt { get; set; } = DateTime.Now;

    public List<Entities.Course> Courses { get; } = [];
}