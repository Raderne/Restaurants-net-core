using MediatR;

namespace Application.Features.Restaurants.Queries.GetRestaurantsList;

public class GetRestaurantsListQuery : IRequest<List<RestaurantListVm>>
{
}
