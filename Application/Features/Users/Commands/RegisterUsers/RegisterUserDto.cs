namespace Application.Features.Users.Commands.RegisterUsers;

public class RegisterUserDto
{
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
