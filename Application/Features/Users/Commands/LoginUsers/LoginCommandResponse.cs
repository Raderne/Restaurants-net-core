using Application.Responses;

namespace Application.Features.Users.Commands.LoginUsers;

public class LoginCommandResponse : BaseResponse
{
    public LoginCommandResponse() : base()
    {
    }

    public LoginUserDto? LoginResponse { get; set; }
}
