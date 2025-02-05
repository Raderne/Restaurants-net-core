using Application.Contracts.Persistence;
using Infrastrucure.Persistence;

namespace Infrastrucure.Repositories;

public class RestaurantTransactionRepository(RestaurantsDbContext dbContext) : IRestaurantTransactionRepository
{
    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        await dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        await dbContext.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        await dbContext.Database.RollbackTransactionAsync(cancellationToken);
    }
}
