using Application.Models;

namespace Application.Interfaces;

public interface INotificationService
{
    Task SendOrderNotificationAsync(OrderCreatedNotification notification);
}
