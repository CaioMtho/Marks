using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Marks.Application.Dto.Bookmark;
using Marks.Application.Interfaces;
using Marks.Application.Models;
using Marks.Core.Entities;
using Marks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Marks.Application.Services;

public class BookmarkService(MarksDbContext context, IMapper mapper) : IBookmarkService
{
    private readonly MarksDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    public async Task<PaginatedResult<BookmarkDto>> GetBookmarksAsync(
        int? page = 1,
        int? pageSize = 10,
        string? filter = null,
        long? userId = null,
        long? folderId = null,
        string? orderBy = "Title",
        string? orderDirection = "asc",
        CancellationToken cancellationToken = default
    )
    {
        var query = _context.Bookmarks.AsQueryable().AsNoTracking();

        if (userId.HasValue)
            query = query.Where(b => b.UserId == userId.Value);

        if (folderId.HasValue)
            query = query.Where(b => b.FolderId == folderId.Value);

        if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(b => b.Title.Contains(filter) || b.Url.Contains(filter));

        var allowedColumns = new[] { "Title", "Url", "CreatedAt" };
        if (!allowedColumns.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            orderBy = "Title";

        var sortExpression = $"{orderBy} {orderDirection ?? "asc"}";
        query = query.OrderBy(sortExpression);

        var projectedQuery = query.ProjectTo<BookmarkDto>(_mapper.ConfigurationProvider);

        var currentPage = page.GetValueOrDefault(1);
        var currentPageSize = pageSize.GetValueOrDefault(10);

        return await PaginatedResult<BookmarkDto>.CreateAsync(
            projectedQuery,
            currentPage,
            currentPageSize,
            cancellationToken
        );
    }

    public async Task<BookmarkDto> CreateBookmarkAsync(BookmarkCreateDto bookmark)
    {
        await _context.Bookmarks.AddAsync(_mapper.Map<Bookmark>(bookmark));
        await _context.SaveChangesAsync();
        return _mapper.Map<BookmarkDto>(bookmark);
    }

    public async Task DeleteBookmarkAsync(long id)
    {
        var bookmark =
            await _context.Bookmarks.FindAsync(id)
            ?? throw new KeyNotFoundException($"Bookmark with id {id} not found.");
        _context.Bookmarks.Remove(bookmark);
        await _context.SaveChangesAsync();
    }

    public async Task<BookmarkDto> GetBookmarkByIdAsync(long id)
    {
        var bookmark =
            await _context.Bookmarks.FindAsync(id)
            ?? throw new KeyNotFoundException($"Bookmark with id {id} not found.");
        return _mapper.Map<BookmarkDto>(bookmark);
    }

    public async Task<BookmarkDto> UpdateBookmarkAsync(
        long id,
        BookmarkUpdateDto dto,
        CancellationToken cancellationToken = default
    )
    {
        var bookmark =
            await _context
                .Bookmarks.Include(b => b.Tags)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException($"Bookmark with id {id} not found.");
        _mapper.Map(dto, bookmark);

        if (dto.TagIds is not null)
        {
            var tags = await _context
                .Tags.Where(t => dto.TagIds.Contains(t.Id))
                .ToListAsync(cancellationToken);

            bookmark.Tags.Clear();
            foreach (var tag in tags)
            {
                bookmark.Tags.Add(tag);
            }
        }

        _context.Bookmarks.Update(bookmark);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<BookmarkDto>(bookmark);
    }
}
