using MediatR;

namespace Application.Features.Restaurants.Queries.GetRestaurantsListWithMenus;

public class GetRestaurantsListWithMenusQuery : IRequest<List<RestaurantsListWithMenusVm>>
{
}
