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
        string? orderBy = null,
        string? orderDirection = null
    );
    Task<BookmarkDto> GetBookmarkByIdAsync(long id);
    Task<BookmarkDto> UpdateBookmarkAsync(BookmarkUpdateDto patch);
    Task<BookmarkDto> CreateBookmarkAsync(BookmarkCreateDto bookmark);
    Task DeleteBookmarkAsync(long id);
}
