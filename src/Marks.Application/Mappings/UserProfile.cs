using AutoMapper;
using Marks.Application.Dto.User;
using Marks.Core.Entities;

namespace Marks.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}