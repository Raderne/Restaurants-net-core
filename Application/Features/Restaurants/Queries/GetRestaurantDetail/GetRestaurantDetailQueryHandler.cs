using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Restaurants.Queries.GetRestaurantDetail;

public class GetRestaurantDetailQueryHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetRestaurantDetailQuery, RestaurantDetailVm>
{
    public async Task<RestaurantDetailVm> Handle(GetRestaurantDetailQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant == null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id);
        }

        return mapper.Map<RestaurantDetailVm>(restaurant);
    }
}
