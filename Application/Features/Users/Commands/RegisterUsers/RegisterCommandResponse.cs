using Application.Responses;

namespace Application.Features.Users.Commands.RegisterUsers;

public class RegisterCommandResponse : BaseResponse
{
    public RegisterCommandResponse() : base()
    {
    }

    public RegisterUserDto RegisteredUser { get; set; } = default!;
}
