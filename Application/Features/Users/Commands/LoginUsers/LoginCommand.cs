using MediatR;

namespace Application.Features.Users.Commands.LoginUsers;

public class LoginCommand : IRequest<LoginCommandResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
