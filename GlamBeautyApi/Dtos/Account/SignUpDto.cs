using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Account;

public class SignUpDto
{
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    public required string Username { get; set; }

    [Required] [EmailAddress] public required string Email { get; set; }

    [Required] public required string Password { get; set; }

    [Required] public required string Role { get; set; }

    [Required] public required string Phone { get; set; }
}