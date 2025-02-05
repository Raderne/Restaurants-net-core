using Application.Contracts.Users;

namespace Identites.Persistence;

public class TransactionRepository(AppIdentityContextDb contextDb) : ITransactionRepository
{
    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        await contextDb.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        await contextDb.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        await contextDb.Database.RollbackTransactionAsync(cancellationToken);
    }
}
