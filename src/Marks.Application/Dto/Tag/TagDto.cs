using Marks.Application.Dto.Bookmark;

namespace Marks.Application.Dto.Tag;

public class TagDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<BookmarkSummaryDto> Bookmarks { get; set; } = [];
}
