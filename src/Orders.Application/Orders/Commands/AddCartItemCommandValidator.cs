using FluentValidation;

namespace Orders.Application.Orders.Commands;

public class AddCartItemCommandValidator : AbstractValidator<AddCartItemCommand>
{
    public AddCartItemCommandValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .LessThanOrEqualTo(10);
    }
}