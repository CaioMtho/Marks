using AutoMapper;
using Marks.Application.Dto.User;
using Marks.Core.Entities;

namespace Marks.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDto, User>()
            .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password))
            );

        CreateMap<User, UserDto>();
        CreateMap<User, UserUpdateDto>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
