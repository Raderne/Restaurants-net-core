using Application.Contracts.Persistence;
using Application.Exceptions;
using Domain.Entities;
using Infrastrucure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucure.Repositories;

public class OrdersRepository(RestaurantsDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{
    public async Task<string> GetRestaurantOwnerByOrder(int? orderId, int? restaurantId)
    {
        var order = await dbContext.Orders.Include(o => o.Restaurant).FirstOrDefaultAsync(o => o.Id == orderId && o.RestaurantId == restaurantId);
        if (order == null)
        {
            throw new NotFoundException(nameof(order), "order not found");
        }

        return order.Restaurant!.OwnerId ?? throw new NotFoundException(nameof(order), "owner error");
    }
}
