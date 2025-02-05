using Application.Contracts.Users;
using MediatR;

namespace Application.Features.Users.Commands.LoginUsers;

public class LoginCommandHandler(IIdentityRepository identityRepository) : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = new LoginCommandResponse();

        var validationResult = await new LoginCommandValidation().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Succeeded = false;
            response.Message = "User login failed";
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        var user = await identityRepository.FindByEmailAsync(request.Email);
        if (user is null)
        {
            response.Succeeded = false;
            response.Message = "User login failed (user exists)";
            return response;
        }

        var passwordValid = await identityRepository.LoginUser(user, request.Password);
        if (!passwordValid.Succeeded)
        {
            response.Succeeded = false;
            response.Message = "Credentials are invalid";
            return response;
        }

        var token = await identityRepository.GenerateTokenAsync(user);
        if (token is null)
        {
            response.Succeeded = false;
            response.Message = "User login failed";
            response.ValidationErrors ??= new List<string>();
            response.ValidationErrors.Add("Token generation failed");
            return response;
        }

        response.Succeeded = true;
        response.Message = "User login successful";
        response.LoginResponse = new LoginUserDto
        {
            Token = token,
            UserName = user.UserName!,
            RefreshToken = token
        };

        return response;
    }
}
