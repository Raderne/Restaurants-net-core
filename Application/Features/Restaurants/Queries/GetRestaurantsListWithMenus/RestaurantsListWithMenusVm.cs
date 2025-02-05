namespace Application.Features.Restaurants.Queries.GetRestaurantsListWithMenus;

public class RestaurantsListWithMenusVm
{
    public string Name { get; set; } = string.Empty;
    public List<RestaurantMenuDto>? Menus { get; set; }
}
