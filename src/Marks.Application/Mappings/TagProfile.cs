using AutoMapper;
using Marks.Application.Dto.Tag;
using Marks.Core.Entities;

namespace Marks.Application.Mappings;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, TagDto>();
        CreateMap<Tag, TagSummaryDto>();

        CreateMap<TagCreateDto, Tag>();
        CreateMap<TagUpdateDto, Tag>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
