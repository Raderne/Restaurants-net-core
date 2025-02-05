using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastrucure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucure.Repositories;

public class RestaurantsRepository : BaseRepository<Restaurant>, IRestaurantsRepository
{
    private readonly RestaurantsDbContext dbContext;

    public RestaurantsRepository(RestaurantsDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Restaurant>> GetRestaurantsByName(string name)
    {
        return await dbContext.Restaurants.Where(r => r.Name == name).ToListAsync();
    }

    public async Task<List<Restaurant>> GetRestaurantsWithMeals()
    {
        return await dbContext.Restaurants.Include(r => r.Menus).ToListAsync();
    }
}
