using Application.Contracts.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identites.Persistence;

public class IdentityRepository(
    UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager,
    SignInManager<AppUser> signInManager,
    IConfiguration configuration) : IIdentityRepository
{
    public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
    {
        var result = await userManager.CreateAsync(user, password);
        return result;
    }

    public async Task<IdentityResult> AddUserToRoleAsync(AppUser user, string roleName)
    {
        var result = await userManager.AddToRoleAsync(user, roleName);
        return result;
    }

    public async Task<bool> RoleExistsAsync(string roleName)
    {
        return await roleManager.RoleExistsAsync(roleName);
    }

    public async Task<bool> UserExistsByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email) != null;
    }

    public async Task<AppUser> FindByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        return user ?? null!;
    }

    public Task<bool> CheckPasswordAsync(AppUser user, string password)
    {
        return userManager.CheckPasswordAsync(user, password);
    }

    public async Task<string> GenerateTokenAsync(AppUser user)
    {
        try
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim("fullName", user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Role, (await userManager.GetRolesAsync(user)).FirstOrDefault()!.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!),
            };

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
        catch (Exception)
        {
            return null!;
        }
    }

    public async Task<SignInResult> LoginUser(AppUser user, string password)
    {
        return await signInManager.CheckPasswordSignInAsync(user, password, false);
    }
}
