using System.ComponentModel.DataAnnotations;
using MediatR;
using Orders.Application.Orders.DTOs;

namespace Orders.Application.Orders.Commands;

public record CheckoutOrderCommand(
    int CartId,
    [AllowedValues("CreditCard", "Cash")] string PaymentMethod,
    string FirstName,
    string LastName,
    string Email,
    string Address,
    string PhoneNumber) : IRequest<OrderResultDto>;