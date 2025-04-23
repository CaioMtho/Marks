namespace Marks.Application.Interfaces;

using Marks.Application.Dto.Tag;
using Marks.Application.Models;

public interface ITagService
{
    Task<TagDto> GetTagByIdAsync(long id);
    Task<TagDto> UpdateTagAsync(TagUpdateDto patch);
    Task<TagDto> CreateTagAsync(TagCreateDto tag);
    Task DeleteTagAsync(long id);
    Task<PaginatedResult<TagDto>> GetTagsAsync(
        int? page = 1,
        int? pageSize = 10,
        string? filter = null,
        long? userId = null,
        string? orderBy = null,
        string? orderDirection = null
    );
}
