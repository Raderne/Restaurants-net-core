
using Application.Features.Users.Commands.LoginUsers;
using Application.Features.Users.Commands.RegisterUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/identity/")]
[ApiController]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterCommandResponse>> RegisterUser([FromBody] RegisterCommand command)
    {
        var response = await mediator.Send(command);
        return CreatedAtAction(nameof(RegisterUser), response);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginCommandResponse>> Login([FromBody] LoginCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }
}
