using DeliveryChannel.BusinessLogic.Orders.Commands.Models;
using DeliveryChannel.Domain.Entities;

namespace DeliveryChannel.BusinessLogic.Common.Mappers;

public static class OrderMapper
{
    public static OrderDto ToOrderDto(this Order order) =>
        new()
        {
            Id = order.Id,
            Total = order.Total,
            Status = nameof(order.Status)
        };
}