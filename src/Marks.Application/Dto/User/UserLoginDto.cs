using System.ComponentModel.DataAnnotations;

namespace Marks.Application.Dto.User;

public class UserLoginDto
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}