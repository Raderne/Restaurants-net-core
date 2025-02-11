using Application.Contracts.Infrastructure;
using Application.Contracts.Users;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.RegisterUsers;

public class RegisterCommandHandler(
    IIdentityRepository identityRepository,
    ITransactionRepository transactionRepository,
    IMapper mapper,
    IEmailService emailService) : IRequestHandler<RegisterCommand, RegisterCommandResponse>
{
    public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        RegisterCommandResponse response = new RegisterCommandResponse();

        var validationResult = await new RegisterCommandValidation().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Succeeded = false;
            response.Message = "User registration failed";
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        var roleExists = await identityRepository.RoleExistsAsync(request.RoleName);
        if (!roleExists)
        {
            response.Succeeded = false;
            response.Message = $"Role {request.RoleName} does not exist";
            return response;
        }

        await transactionRepository.BeginTransactionAsync(cancellationToken);
        try
        {
            AppUser newUser = new AppUser
            {
                Email = request.UserEmail,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var createUser = await identityRepository.CreateUserAsync(newUser, request.Password);
            if (!createUser.Succeeded)
            {
                await transactionRepository.RollbackTransactionAsync(cancellationToken);
                response.Succeeded = false;
                response.Message = "User registration failed";
                response.ValidationErrors = createUser.Errors.Select(e => e.Description).ToList();
                return response;
            }

            var addUserToRole = await identityRepository.AddUserToRoleAsync(newUser, request.RoleName);
            if (!addUserToRole.Succeeded)
            {
                await transactionRepository.RollbackTransactionAsync(cancellationToken);
                response.Succeeded = false;
                response.Message = "User registration failed";
                response.ValidationErrors = addUserToRole.Errors.Select(e => e.Description).ToList();
                return response;
            }

            await transactionRepository.CommitTransactionAsync(cancellationToken);

            var emailContent = $"<h1>Welcome {newUser.FirstName} {newUser.LastName}</h1>" +
                $"<p>Your registration is successful</p>";

            await emailService.SendEmailAsync("relmarzouki@gmail.com", "Welcome To Restaurants App", emailContent);

            response.Message = "User registration successful";
            response.RegisteredUser = mapper.Map<RegisterUserDto>(newUser);

            return response;
        }
        catch (Exception ex)
        {
            await transactionRepository.RollbackTransactionAsync(cancellationToken);
            response.Succeeded = false;
            response.Message = "User registration failed";
            response.ValidationErrors = new List<string> { ex.Message };
            return response;
        }
    }
}
