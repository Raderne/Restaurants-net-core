using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Users;

public interface IIdentityRepository
{
    Task<IdentityResult> CreateUserAsync(AppUser user, string password);
    Task<IdentityResult> AddUserToRoleAsync(AppUser user, string roleName);
    Task<bool> RoleExistsAsync(string roleName);
    Task<bool> UserExistsByEmailAsync(string email);
    Task<AppUser> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(AppUser user, string password);
    Task<string> GenerateTokenAsync(AppUser user);
    Task<SignInResult> LoginUser(AppUser user, string password);
}
