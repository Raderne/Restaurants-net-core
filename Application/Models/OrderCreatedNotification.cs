namespace Application.Models;

public class OrderCreatedNotification
{
    public int OrderId { get; set; }
    public string? ownerId { get; set; }
    public string? CustomerName { get; set; }
    public DateTime CreatedAt { get; set; }
}
