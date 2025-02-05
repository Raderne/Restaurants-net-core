using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IMenusRepository : IAsyncRepository<Menu>
{
}
