using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Interfaces;
using MediatR;
using Orders.Application.Payments.DTOs;

namespace Orders.Application.Payments.Commands;

public class CreatePaymentCommandHandler(IApplicationDbContext context) : IRequestHandler<CreatePaymentCommand, PaymentDto>
{
    public async Task<PaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
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
        await context.SaveChangesAsync(cancellationToken);

        return new PaymentDto
        {
            OrderId = payment.OrderId,
            Status = payment.Status.ToString(),
            PaymentDate = payment.PaymentDate
        };
    }
}