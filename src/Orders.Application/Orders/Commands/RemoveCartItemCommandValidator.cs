using FluentValidation;

namespace Orders.Application.Orders.Commands;

public class RemoveCartItemCommandValidator : AbstractValidator<RemoveCartItemCommand>
{
    public RemoveCartItemCommandValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .LessThan(10);
    }
}