using Core.Domain.Enums;
using FluentValidation;

namespace Orders.Application.Orders.Commands;

public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(command => command.Email)
            .EmailAddress();
        RuleFor(command => command.PaymentMethod)
            .IsEnumName(typeof(PaymentMethod));
    }
}