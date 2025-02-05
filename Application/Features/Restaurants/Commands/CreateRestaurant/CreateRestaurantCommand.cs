using MediatR;

namespace Application.Features.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommand : IRequest<CreateRestaurantCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }
}
