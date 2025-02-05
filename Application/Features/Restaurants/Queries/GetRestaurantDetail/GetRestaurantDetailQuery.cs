using MediatR;

namespace Application.Features.Restaurants.Queries.GetRestaurantDetail;

public class GetRestaurantDetailQuery : IRequest<RestaurantDetailVm>
{
    public int Id { get; set; }
}
