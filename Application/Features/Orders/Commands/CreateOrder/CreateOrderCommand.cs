using MediatR;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest
{
    public int RestaurantId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
}
