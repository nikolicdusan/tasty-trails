using Core.Domain.Enums;
using FluentValidation;

namespace Orders.Application.Payments.Commands;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0);
        RuleFor(x => x.PaymentMethod)
            .IsEnumName(typeof(PaymentMethod));
        RuleFor(x => x.Status)
            .IsEnumName(typeof(PaymentStatus));
    }
}