using Application.Features.Restaurants.Commands.CreateRestaurant;
using Application.Features.Restaurants.Commands.UpdateRestaurant;
using Application.Features.Restaurants.Queries.GetRestaurantDetail;
using Application.Features.Restaurants.Queries.GetRestaurantsList;
using Application.Features.Restaurants.Queries.GetRestaurantsListWithMenus;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet("all", Name = "GetAllRestaurants")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<RestaurantListVm>>> GetAllRestaurants()
    {
        return Ok(await mediator.Send(new GetRestaurantsListQuery()));
    }

    [HttpGet("allwithmenus", Name = "GetAllRestaurantsWithMenus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<RestaurantsListWithMenusVm>>> GetAllRestaurantsWithMenus()
    {
        return Ok(await mediator.Send(new GetRestaurantsListWithMenusQuery()));
    }

    [HttpGet("{id}", Name = "GetRestaurant")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RestaurantDetailVm>> GetRestaurant(int id)
    {
        return Ok(await mediator.Send(new GetRestaurantDetailQuery { Id = id }));
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = $"{UsersRoles.ADMIN}, {UsersRoles.MODERATOR}")]
    public async Task<ActionResult<CreateRestaurantCommandResponse>> AddRestaurant([FromBody] CreateRestaurantCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public async Task<ActionResult<UpdateRestaurantCommandResponse>> UpdateRestaurant([FromBody] UpdateRestaurantCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}
