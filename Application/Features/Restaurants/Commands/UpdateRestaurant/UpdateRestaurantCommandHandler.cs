using Application.Contracts.Persistence;
using Application.Contracts.Users;
using Application.Exceptions;
using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(
    IRestaurantsRepository restaurantsRepository,
    IRestaurantTransactionRepository transactionRepository,
    IRestaurantsAuthorizeService authorizeService,
    IUserContext userContext,
    IMapper mapper
    ) : IRequestHandler<UpdateRestaurantCommand, UpdateRestaurantCommandResponse>
{
    public async Task<UpdateRestaurantCommandResponse> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurantToUpdate = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurantToUpdate == null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id);
        }

        var response = new UpdateRestaurantCommandResponse();

        var loggedInUser = userContext.GetCurrentUser();
        if (loggedInUser == null)
        {
            response.Succeeded = false;
            response.Message = "User not found";
            return response;
        }

        if (!response.Succeeded)
            return response;

        await transactionRepository.BeginTransactionAsync(cancellationToken);
        try
        {
            if (!authorizeService.AuthorizeAsync(ResourceOperation.update, restaurantToUpdate.OwnerId!))
            {
                await transactionRepository.RollbackTransactionAsync(cancellationToken);
                response.Succeeded = false;
                response.Message = "You are not authorized to update this restaurant";
                return response;
            }

            var validationResult = await new UpdateRestaurantCommandValidator().ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                response.Succeeded = false;
                response.Message = "Updating is not valid";
                response.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            mapper.Map(request, restaurantToUpdate, typeof(UpdateRestaurantCommand), typeof(Restaurant));

            await restaurantsRepository.UpdateAsync(restaurantToUpdate);
            await transactionRepository.CommitTransactionAsync(cancellationToken);

            response.Message = "Restaurant updated";
            return response;
        }
        catch (Exception)
        {
            await transactionRepository.RollbackTransactionAsync(cancellationToken);
            response.Succeeded = false;
            response.Message = "Updating failed";
            return response;
        }
    }
}
