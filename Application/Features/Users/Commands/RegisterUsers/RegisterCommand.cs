using MediatR;

namespace Application.Features.Users.Commands.RegisterUsers;

public class RegisterCommand : IRequest<RegisterCommandResponse>
{
    public string UserEmail { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string PasswordConfirmation { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
