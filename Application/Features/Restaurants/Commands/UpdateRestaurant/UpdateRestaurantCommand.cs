using MediatR;

namespace Application.Features.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommand : IRequest<UpdateRestaurantCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
