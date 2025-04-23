using Marks.Application.Dto.Bookmark;

namespace Marks.Application.Dto.Folder;

public class FolderDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public List<BookmarkSummaryDto> Bookmarks { get; set; } = [];
}
