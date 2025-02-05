using Api.Hubs;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.SignalR;

namespace Api.Services;

public class NotificationService(IHubContext<OrderHub, IOrderHubClient> hubContext) : INotificationService
{
    public async Task SendOrderNotificationAsync(OrderCreatedNotification notification)
    {
        await hubContext.Clients.User(notification.ownerId!).ReceiveOrderNotification(notification);
    }
}
