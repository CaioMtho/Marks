using System.Security.Claims;
using Marks.Core.Entities;

namespace Marks.Application.Interfaces;

public interface ITokenService
{
    string? GenerateToken(User user);
    ClaimsPrincipal? ValidateToken(string token);
}