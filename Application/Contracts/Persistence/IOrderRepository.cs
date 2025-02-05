using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<string> GetRestaurantOwnerByOrder(int? orderId, int? restaurantId);
}
