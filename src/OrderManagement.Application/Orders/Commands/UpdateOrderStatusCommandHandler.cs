using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using OrderManagement.Application.Orders.Events;

namespace OrderManagement.Application.Orders.Commands;

public class UpdateOrderStatusCommandHandler(IApplicationDbContext context, IPublisher publisher) : IRequestHandler<UpdateOrderStatusCommand>
{
    public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .FindAsync(new object?[] { request.OrderId }, cancellationToken);
        if (order is null)
        {
            throw new NotFoundException(nameof(Order), request.OrderId);
        }

        order.Status = Enum.Parse<OrderStatus>(request.Status);

        await context.SaveChangesAsync(cancellationToken);

        await publisher.Publish(new OrderUpdatedEvent(order.Id), cancellationToken);
    }
}