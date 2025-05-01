using Marks.Application.Dto.Tag;

public class BookmarkDto
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public long FolderId { get; set; }
    public string? FolderName { get; set; }

    public ICollection<TagSummaryDto> Tags { get; set; } = [];

    public long UserId { get; set; }
}
