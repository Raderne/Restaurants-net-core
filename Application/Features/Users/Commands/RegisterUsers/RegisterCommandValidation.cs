using FluentValidation;

namespace Application.Features.Users.Commands.RegisterUsers;

public class RegisterCommandValidation : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidation()
    {
        RuleFor(p => p.UserEmail)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address.");

        RuleFor(p => p.UserName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} must not be less than 6 characters.");

        RuleFor(p => p.PasswordConfirmation)
            .Equal(p => p.Password).WithMessage("Passwords do not match.");

        RuleFor(p => p.RoleName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}
