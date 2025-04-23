using System.ComponentModel.DataAnnotations;

namespace Marks.Application.Dto.User;

public class UserCreateDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
    public required string Username { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    [MinLength(5, ErrorMessage = "Email must be at least 5 characters long.")]
    public required string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    public required string Password { get; set; }
}
