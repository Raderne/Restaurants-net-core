namespace Application.Features.Restaurants.Queries.GetRestaurantsListWithMenus;

public class RestaurantMenuDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; } = 0.00m;
    public string? ImageUrl { get; set; }
}
