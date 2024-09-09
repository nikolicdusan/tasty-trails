using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Common.Mappers;
using DeliveryChannel.BusinessLogic.Orders.Models;
using DeliveryChannel.Domain.Entities;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Orders.Queries.GetOrderStatus;

public class GetOrderStatusQueryHandler(IRestaurantDbContext context) : IRequestHandler<GetOrderStatusQuery, OrderStatusDto>
{
    public async Task<OrderStatusDto> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .FindAsync(new object?[] { request.OrderId },
                cancellationToken);

        if (order is null)
        {
            throw new NotFoundException(nameof(Order), request.OrderId);
        }

        return order.ToOrderStatusDto();
    }
}