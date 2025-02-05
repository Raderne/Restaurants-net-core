namespace Application.Features.Restaurants.Queries.GetRestaurantDetail;

public class RestaurantDetailVm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public string? OwnerId { get; set; }
}
