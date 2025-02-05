using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Restaurants.Queries.GetRestaurantsList;

public class GetRestaurantsListQueryHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetRestaurantsListQuery, List<RestaurantListVm>>
{
    public async Task<List<RestaurantListVm>> Handle(GetRestaurantsListQuery request, CancellationToken cancellationToken)
    {
        var allRestaurants = (await restaurantsRepository.ListAllAsync()).OrderBy(x => x.Name);
        return mapper.Map<List<RestaurantListVm>>(allRestaurants);
    }
}
