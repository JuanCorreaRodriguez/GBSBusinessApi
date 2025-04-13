using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Account;

public class SignInDto
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}