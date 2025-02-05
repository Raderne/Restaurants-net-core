using Domain.Common;

namespace Domain.Entities;

public class Menu : AuditableEntry
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; } = 0.00m;
    public string? ImageUrl { get; set; }

    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = default!;
}
