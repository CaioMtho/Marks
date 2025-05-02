using System.Security.Claims;
using Marks.Application.Interfaces;
using Marks.Core.Entities;

namespace Marks.Application.Services;

public class JwtService : ITokenService
{
    public string? GenerateToken(User user)
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}
