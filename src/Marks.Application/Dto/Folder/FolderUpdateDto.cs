using System.ComponentModel.DataAnnotations;

namespace Marks.Application.Dto.Folder;

public class FolderUpdateDTO
{
    [MaxLength(100)]
    public string? Name { get; set; }

    public long? ParentId { get; set; }
}
