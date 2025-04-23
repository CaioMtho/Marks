using System.ComponentModel.DataAnnotations;

namespace Marks.Application.Dto.Bookmark;

public class BookmarkCreateDto
{
    [Required]
    [MaxLength(255, ErrorMessage = "Title cannot be longer than 255 characters.")]
    [MinLength(3, ErrorMessage = "Title cannot be shorter than 3 characters.")]
    public required string Title { get; set; }

    [Required]
    public required string Url { get; set; } = null!;
    public long? FolderId { get; set; }
    public ICollection<long> TagIds { get; set; } = [];
}
