using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastrucure.Persistence;

namespace Infrastrucure.Repositories;

public class MenusRepository(RestaurantsDbContext dbContext) : BaseRepository<Menu>(dbContext), IMenusRepository
{
}
