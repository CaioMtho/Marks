namespace Marks.Application.Dto.Bookmark;

public class BookmarkSummaryDto
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
}