using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Interfaces;
using MediatR;
using Orders.Application.Payments.DTOs;

namespace Orders.Application.Payments.Commands;

public class CreatePaymentCommandHandler(IApplicationDbContext context) : IRequestHandler<CreatePaymentCommand, PaymentResult>
{
    public async Task<PaymentResult> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
            OrderId = request.OrderId,
            TransactionId = request.TransactionId,
            Amount = request.Amount,
            PaymentMethod = Enum.Parse<PaymentMethod>(request.PaymentMethod),
            Status = Enum.Parse<PaymentStatus>(request.Status),
            PaymentDate = request.PaymentDate
        };

        context.Payments.Add(payment);

        var order = await context.Orders
            .FindAsync(new object?[] { request.OrderId }, cancellationToken);

        if (order is { Status: OrderStatus.PendingPayment })
        {
            order.Status = OrderStatus.PendingConfirmation;
        }

        await context.SaveChangesAsync(cancellationToken);

        return new PaymentResult
        {
            OrderId = payment.OrderId,
            Status = payment.Status.ToString(),
            PaymentDate = payment.PaymentDate
        };
    }
}