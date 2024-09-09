using DeliveryChannel.BusinessLogic.Orders.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Orders.Queries.GetOrderStatus;

public record GetOrderStatusQuery(long OrderId) : IRequest<OrderStatusDto>;
