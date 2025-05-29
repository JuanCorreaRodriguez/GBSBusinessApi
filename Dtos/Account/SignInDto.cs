using System.ComponentModel.DataAnnotations;

namespace GBSApi.Dtos.Account;

public class SignInDto
{
    [Required] [MaxLength(50)] public required string Username { get; set; }

    [Required] [MinLength(8)] public required string Password { get; set; }
}