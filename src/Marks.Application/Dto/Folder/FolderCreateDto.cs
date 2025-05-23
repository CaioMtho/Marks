using System.ComponentModel.DataAnnotations;

namespace Marks.Application.Dto.Folder;

public class FolderCreateDto
{
    [MaxLength(100)]
    public string? Name { get; set; }

    public long? ParentId { get; set; }
    [Required]
    public long UserId { get; set; }
}
