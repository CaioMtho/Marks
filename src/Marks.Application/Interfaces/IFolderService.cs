namespace Marks.Application.Interfaces;

using Dto.Folder;
using Models;

public interface IFolderService
{
    Task<PaginatedResult<FolderDto>> GetFoldersAsync(
        int? page = 1,
        int? pageSize = 10,
        string? filter = null,
        long? userId = null,
        string? orderBy = null,
        string? orderDirection = null
    );
    Task<FolderDto> GetFolderByIdAsync(long id);
    Task<FolderDto> UpdateFolderAsync(long id, FolderUpdateDto patch);
    Task<FolderDto> CreateFolderAsync(FolderCreateDto folder);
    Task DeleteFolderAsync(long id);
}
