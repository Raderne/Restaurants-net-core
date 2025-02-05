using Application.Models;

namespace Application.Interfaces;

public interface IOrderHubClient
{
    Task ReceiveOrderNotification(OrderCreatedNotification notification);
}
