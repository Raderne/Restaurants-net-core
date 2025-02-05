namespace Application.Features.Users.Commands.LoginUsers;

public class LoginUserDto
{
    public string Token { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public string UserName { get; set; } = null!;
}
