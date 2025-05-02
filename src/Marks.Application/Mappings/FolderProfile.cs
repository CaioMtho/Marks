using AutoMapper;
using Marks.Application.Dto.Bookmark;
using Marks.Application.Dto.Folder;
using Marks.Core.Entities;

namespace Marks.Application.Mappings;

public class FolderProfile : Profile
{
    public FolderProfile()
    {
        CreateMap<Folder, FolderDto>()
            .ForMember(
                dest => dest.Bookmarks,
                opt =>
                    opt.MapFrom(src =>
                        src.Bookmarks.Select(b => new BookmarkSummaryDto
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Url = b.Url,
                        })
                    )
            );
        CreateMap<FolderCreateDto, Folder>();
        CreateMap<FolderUpdateDto, Folder>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
