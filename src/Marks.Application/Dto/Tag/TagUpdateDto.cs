using System.ComponentModel.DataAnnotations;

namespace Marks.Application.Dto.Tag;

public class TagUpdateDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Tag name must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "Tag name cannot exceed 50 characters.")]
    public required string Name { get; set; }
}