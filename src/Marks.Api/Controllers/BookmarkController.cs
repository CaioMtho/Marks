using Marks.Application.Dto.Bookmark;
using Marks.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marks.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookmarkController(IBookmarkService bookmarkService) : ControllerBase
{
    private readonly IBookmarkService _bookmarkService = bookmarkService;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookmarkById(long id)
    {
        var bookmark = await _bookmarkService.GetBookmarkByIdAsync(id);

        return Ok(bookmark);
    }

    [HttpGet]
    public async Task<IActionResult> GetBookmarks(
        [FromQuery] int? page = 1,
        [FromQuery] int? pageSize = 10,
        [FromQuery] string? filter = null,
        [FromQuery] long? userId = null,
        [FromQuery] long? folderId = null,
        [FromQuery] string? orderBy = "Title",
        [FromQuery] string? orderDirection = "asc",
        CancellationToken cancellationToken = default
    )
    {
        var result = await _bookmarkService.GetBookmarksAsync(
            page,
            pageSize,
            filter,
            userId,
            folderId,
            orderBy,
            orderDirection,
            cancellationToken
        );
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookmark([FromBody] BookmarkCreateDto bookmark)
    {
        var createdBookmark = await _bookmarkService.CreateBookmarkAsync(bookmark);
        return CreatedAtAction(
            nameof(GetBookmarkById),
            new { id = createdBookmark.Id },
            createdBookmark
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookmark(long id)
    {
        await _bookmarkService.DeleteBookmarkAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBookmark(
        long id,
        [FromBody] BookmarkUpdateDto dto,
        CancellationToken cancellationToken = default
    )
    {
        var updatedBookmark = await _bookmarkService.UpdateBookmarkAsync(
            id,
            dto,
            cancellationToken
        );

        return Ok(updatedBookmark);
    }
}
