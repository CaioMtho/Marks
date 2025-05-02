using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Marks.Application.Dto.Folder;
using Marks.Application.Interfaces;
using Marks.Application.Models;
using Marks.Core.Entities;
using Marks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Marks.Application.Services;

public class FolderService(MarksDbContext context, IMapper mapper) : IFolderService
{
    private readonly MarksDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<FolderDto>> GetFoldersAsync(
        int? page,
        int? pageSize,
        string? filter = null,
        long? userId = null,
        string? orderBy = null,
        string? orderDirection = null
    )
    {
        var query = _context.Folders.AsQueryable().AsNoTracking();

        if (userId.HasValue)
            query = query.Where(f => f.UserId == userId.Value);

        if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(f => f.Name.Contains(filter));

        var allowedColumns = new[] { "Name", "CreatedAt" };
        if (!allowedColumns.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            orderBy = "CreatedAt";

        var sortExpression = $"{orderBy} {orderDirection ?? "asc"}";
        query = query.Include(f => f.Bookmarks).OrderBy(sortExpression);

        var projectedQuery = query.ProjectTo<FolderDto>(_mapper.ConfigurationProvider);

        var currentPage = page.GetValueOrDefault(1);
        var currentPageSize = pageSize.GetValueOrDefault(10);

        return await PaginatedResult<FolderDto>.CreateAsync(
            projectedQuery,
            currentPage,
            currentPageSize
        );
    }

    public async Task<FolderDto> GetFolderByIdAsync(long id)
    {
        var folder =
            await _context.Folders.FindAsync(id)
            ?? throw new KeyNotFoundException($"Folder with id {id} not found");
        return _mapper.Map<FolderDto>(folder);
    }

    public async Task<FolderDto> UpdateFolderAsync(long id, FolderUpdateDto patch)
    {
        var folder =
            await _context.Folders.FindAsync(id)
            ?? throw new KeyNotFoundException($"Folder with id {id} not found");
        _mapper.Map(patch, folder);
        await _context.SaveChangesAsync();
        return _mapper.Map<FolderDto>(folder);
    }

    public async Task<FolderDto> CreateFolderAsync(FolderCreateDto folder)
    {
        var createdFolder = _mapper.Map<Folder>(folder);
        await _context.Folders.AddAsync(createdFolder);
        await _context.SaveChangesAsync();
        return _mapper.Map<FolderDto>(createdFolder);
    }

    public async Task DeleteFolderAsync(long id)
    {
        var folder =
            await _context.Folders.FindAsync(id)
            ?? throw new KeyNotFoundException($"Folder with id {id} not found");
        _context.Folders.Remove(folder);
        await _context.SaveChangesAsync();
    }
}
