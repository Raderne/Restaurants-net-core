using FluentValidation;

namespace Application.Features.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");
        RuleFor(x => x.Phone)
            .MaximumLength(20).WithMessage("Phone must not exceed 20 characters.");
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email is not a valid email address.")
            .MaximumLength(200).WithMessage("Email must not exceed 200 characters.");
    }
}
