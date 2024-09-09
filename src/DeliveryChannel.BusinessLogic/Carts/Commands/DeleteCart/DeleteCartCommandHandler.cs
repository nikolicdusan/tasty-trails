using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Carts.Commands.DeleteCart;

public class DeleteCartCommandHandler(IRestaurantDbContext context) : IRequestHandler<DeleteCartCommand>
{
    public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .FirstOrDefaultAsync(e => e.Id == request.CartId && !e.IsCheckedOut,
                cancellationToken);

        if (cart is null)
        {
            throw new NotFoundException(nameof(Cart), request.CartId);
        }

        context.Carts.Remove(cart);
        await context.SaveChangesAsync(cancellationToken);
    }
}