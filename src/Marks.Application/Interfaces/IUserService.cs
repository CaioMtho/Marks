namespace Marks.Application.Interfaces;

using Dto.User;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(long id);
    Task<UserDto> UpdateUserAsync(long id, UserUpdateDto patch);
    Task<UserDto> CreateUserAsync(UserCreateDto user);
    Task DeleteUserAsync(long id);
    Task<string?> Authenticate(string email, string password);
    
}
