using System.ComponentModel.DataAnnotations;

namespace Marks.Application.Dto.User;

public class UserUpdateDto
{
    [MinLength(3, ErrorMessage = "Username cannot be shorter than 3 characters.")]
    [MaxLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
    public string? Username { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 characters.")]
    public string? Password { get; set; }
    public DateTime LastUpdatedAt = DateTime.UtcNow;
}
