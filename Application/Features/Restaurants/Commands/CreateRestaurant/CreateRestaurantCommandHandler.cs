using Application.Contracts.Persistence;
using Application.Contracts.Users;
using Domain.Entities;
using MediatR;

namespace Application.Features.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(
    IRestaurantsRepository restaurantsRepository,
    IRestaurantTransactionRepository transactionRepository,
    IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, CreateRestaurantCommandResponse>
{
    public async Task<CreateRestaurantCommandResponse> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateRestaurantCommandResponse();

        var validationResult = await new CreateRestaurantCommandValidator().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Succeeded = false;
            response.Message = "Validation errors occurred.";
            response.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            return response;
        }

        var owner = userContext.GetCurrentUser();

        await transactionRepository.BeginTransactionAsync(cancellationToken);
        try
        {
            var restaurant = new Restaurant
            {
                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                OwnerId = owner!.UserId
            };

            var result = await restaurantsRepository.AddAsync(restaurant);
            if (result == null)
            {
                await transactionRepository.RollbackTransactionAsync(cancellationToken);
                response.Succeeded = false;
                response.Message = "An error occurred when creating the restaurant.";
                return response;
            }

            await transactionRepository.CommitTransactionAsync(cancellationToken);
            response.Succeeded = true;
            response.Message = "Restaurant created successfully.";
            return response;
        }
        catch (Exception)
        {
            await transactionRepository.RollbackTransactionAsync(cancellationToken);
            response.Succeeded = false;
            response.Message = "An error occurred when creating the restaurant.";
            return response;
        }
    }
}
