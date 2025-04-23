using AutoMapper;
using Marks.Application.Dto.Folder;
using Marks.Core.Entities;

namespace Marks.Application.Mappings;

public class FolderProfile : Profile
{
    public FolderProfile()
    {
        CreateMap<Folder, FolderDto>();
        CreateMap<FolderCreateDto, Folder>();
        CreateMap<FolderUpdateDto, Folder>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));    
    }
}