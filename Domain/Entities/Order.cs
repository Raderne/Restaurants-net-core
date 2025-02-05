using Domain.Common;

namespace Domain.Entities;

public class Order : AuditableEntry
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }

    public int? RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
}
