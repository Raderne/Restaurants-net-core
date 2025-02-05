using Application.Contracts.Users;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Identites.Persistence;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;
        if (user == null)
        {
            throw new NotFoundException("User", "User not found");
        }

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var email = user.FindFirstValue(ClaimTypes.Email);
        var fullName = user.FindFirstValue("fullName");
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

        return new CurrentUser(userId!, email!, fullName!, roles);
    }
}
