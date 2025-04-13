using System.ComponentModel.DataAnnotations;

namespace GlamBeautyApi.Dtos.Account;

public class SignUpDto
{
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    public string Username { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }

    [Required] public string Role { get; set; }
    [Required] public string Phone { get; set; }
}