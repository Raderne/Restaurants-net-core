using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IRestaurantsRepository : IAsyncRepository<Restaurant>
{
    Task<List<Restaurant>> GetRestaurantsWithMeals();
    Task<List<Restaurant>> GetRestaurantsByName(string name);

    //Task<bool> IsRestaurantOwner(int restaurantId, int ownerId);
}
