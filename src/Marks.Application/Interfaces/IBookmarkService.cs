using Marks.Application.Dto.Bookmark;
using Marks.Application.Models;

namespace Marks.Application.Interfaces;

public interface IBookmarkService
{
    Task<PaginatedResult<BookmarkDto>> GetBookmarksAsync(
        int? page = 1,
        int? pageSize = 10,
        string? filter = null,
        long? userId = null,
        long? folderId = null,
        string? orderBy = "Title",
        string? orderDirection = "asc",
        CancellationToken cancellationToken = default
    );
    Task<BookmarkDto> GetBookmarkByIdAsync(long id);
    Task<BookmarkDto> UpdateBookmarkAsync(
        long id,
        BookmarkUpdateDto dto,
        CancellationToken cancellationToken = default
    );
    Task<BookmarkDto> CreateBookmarkAsync(BookmarkCreateDto bookmark);
    Task DeleteBookmarkAsync(long id);
}
