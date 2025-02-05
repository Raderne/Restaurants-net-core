using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Restaurants.Queries.GetRestaurantsListWithMenus;

public class GetRestaurantsListWithMenusQueryHandler(
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetRestaurantsListWithMenusQuery, List<RestaurantsListWithMenusVm>>
{
    public async Task<List<RestaurantsListWithMenusVm>> Handle(GetRestaurantsListWithMenusQuery request, CancellationToken cancellationToken)
    {
        var allRestaurants = await restaurantsRepository.GetRestaurantsWithMeals();
        if (allRestaurants is null)
        {
            throw new NotFoundException(nameof(Restaurant), request);
        }

        var restaurantsListWithMenus = mapper.Map<List<RestaurantsListWithMenusVm>>(allRestaurants);
        return restaurantsListWithMenus;
    }
}
