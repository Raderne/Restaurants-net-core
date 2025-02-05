using Application.Contracts.Users;
using Domain.Entities;
using Domain.Interfaces;
using Identites.Authorization;
using Identites.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identites;

public static class AppIdentitiesServicesExtension
{
    public static IServiceCollection AddIdentitiesServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppIdentityContextDb>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
        });

        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        })
            .AddEntityFrameworkStores<AppIdentityContextDb>()
            .AddSignInManager();

        services.AddAuthentication(opts =>
        {
            opts.DefaultAuthenticateScheme =
            opts.DefaultChallengeScheme =
            opts.DefaultForbidScheme =
            opts.DefaultScheme =
            opts.DefaultSignInScheme =
            opts.DefaultSignOutScheme =
                JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opts =>
        {
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };

            opts.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];

                    Console.WriteLine($"Access token: {accessToken}");

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        context.Token = accessToken;
                        var token = new JwtSecurityToken(accessToken);
                        var claims = new ClaimsIdentity(token.Claims);
                        context.HttpContext.User = new ClaimsPrincipal(claims);
                    }
                    else
                    {
                        Console.WriteLine("No access token found in query string.");
                    }

                    return Task.CompletedTask;
                }
            };
        });

        services.AddAuthorization();

        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IRestaurantsAuthorizeService, RestaurantsAuthorizeService>();

        services.AddHttpContextAccessor();

        return services;
    }
}
