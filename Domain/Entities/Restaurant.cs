using Domain.Common;

namespace Domain.Entities;

public class Restaurant : AuditableEntry
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public string? OwnerId { get; set; }

    public IEnumerable<Menu> Menus { get; set; } = new List<Menu>();
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();

}
