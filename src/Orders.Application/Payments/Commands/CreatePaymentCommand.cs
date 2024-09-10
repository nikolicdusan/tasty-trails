using MediatR;
using Orders.Application.Payments.DTOs;

namespace Orders.Application.Payments.Commands;

public record CreatePaymentCommand(
    int OrderId,
    string TransactionId,
    decimal Amount,
    string PaymentMethod,
    string Status,
    DateTime PaymentDate) : IRequest<PaymentDto>;