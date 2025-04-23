namespace Marks.Application.Interfaces;

using Marks.Application.Dto.User;
using Marks.Application.Models;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(long id);
    Task<UserDto> UpdateUserAsync(UserUpdateDto patch);
    Task<UserDto> CreateUserAsync(UserCreateDto user);
    Task DeleteUserAsync(long id);
}
