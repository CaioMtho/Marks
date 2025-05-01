using AutoMapper;
using Marks.Application.Dto.User;
using Marks.Application.Interfaces;
using Marks.Core.Entities;
using Marks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Marks.Application.Services;

public class UserService(MarksDbContext context, ITokenService tokenService, IMapper mapper) : IUserService
{
    private readonly MarksDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly ITokenService _tokenService = tokenService;
    public async Task<UserDto> GetUserByIdAsync(long id)
    {
        var user = await _context.Users.FindAsync(id) 
                   ?? throw new KeyNotFoundException($"User with id: {id} not found");
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUserAsync(long id, UserUpdateDto patch)
    {
        var user = await _context.Users.FindAsync(id) 
                   ?? throw new KeyNotFoundException($"User with id: {id} not found");
        _mapper.Map(patch, user);
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateUserAsync(UserCreateDto user)
    {
        var createdUser = _mapper.Map<User>(user);
        await _context.AddAsync(createdUser);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDto>(createdUser);
    }

    public async Task DeleteUserAsync(long id)
    {
        var user = await _context.Users.FindAsync(id) 
                   ?? throw new KeyNotFoundException($"User with id: {id} not found");
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task<string?> Authenticate(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null;

        return _tokenService.GenerateToken(user);
    }

}