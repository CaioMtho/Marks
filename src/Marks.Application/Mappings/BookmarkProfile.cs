using AutoMapper;
using Marks.Application.Dto.Bookmark;
using Marks.Core.Entities;

namespace Marks.Application.Mappings;

public class BookmarkProfile : Profile
{
    public BookmarkProfile()
    {
        CreateMap<Bookmark, BookmarkDto>();
        CreateMap<Bookmark, BookmarkSummaryDto>();
        CreateMap<BookmarkCreateDto, Bookmark>();
        CreateMap<BookmarkUpdateDto, Bookmark>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

    }
}