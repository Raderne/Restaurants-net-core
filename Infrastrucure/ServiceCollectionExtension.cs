using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Domain.Configurations;
using Domain.Constants;
using Infrastrucure.Mail;
using Infrastrucure.Persistence;
using Infrastrucure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrucure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.Configure<EmailOptions>(configuration.GetSection(ConfigurationConstants.Sections.Mail));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IRestaurantTransactionRepository, RestaurantTransactionRepository>();

        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IMenusRepository, MenusRepository>();
        services.AddScoped<IOrderRepository, OrdersRepository>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
