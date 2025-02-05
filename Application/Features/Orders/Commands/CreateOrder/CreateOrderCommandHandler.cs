using Application.Contracts.Persistence;
using Application.Contracts.Users;
using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IRestaurantTransactionRepository transactionRepository,
    INotificationService notificationService,
    IUserContext userContext,
    IMapper mapper) : IRequestHandler<CreateOrderCommand>
{
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await transactionRepository.BeginTransactionAsync(cancellationToken);
        try
        {
            var order = mapper.Map<Order>(request);
            await orderRepository.AddAsync(order);
            await transactionRepository.CommitTransactionAsync(cancellationToken);

            var ownerId = await orderRepository.GetRestaurantOwnerByOrder(order.Id, order.RestaurantId);
            var user = userContext.GetCurrentUser();
            if (user != null && user.UserId == ownerId)
            {
                await notificationService.SendOrderNotificationAsync(new OrderCreatedNotification
                {
                    OrderId = order.Id,
                    ownerId = ownerId,
                    CustomerName = order.CustomerName!,
                    CreatedAt = DateTime.UtcNow
                });
            }

        }
        catch (Exception ex)
        {
            await transactionRepository.RollbackTransactionAsync(cancellationToken);
            throw new NotFoundException(nameof(ex), ex.Message);
        }
    }
}
