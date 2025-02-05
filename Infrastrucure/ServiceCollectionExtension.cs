using Application.Contracts.Persistence;
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

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IRestaurantTransactionRepository, RestaurantTransactionRepository>();

        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IMenusRepository, MenusRepository>();
        services.AddScoped<IOrderRepository, OrdersRepository>();


        return services;
    }
}
