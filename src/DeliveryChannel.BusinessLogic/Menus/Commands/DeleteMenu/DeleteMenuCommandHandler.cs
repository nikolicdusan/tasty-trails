using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.Domain.Entities;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Menus.Commands.DeleteMenu;

public class DeleteMenuCommandHandler(IRestaurantDbContext context) : IRequestHandler<DeleteMenuCommand>
{
    public async Task Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await context.Menus
            .FindAsync(request.Id, cancellationToken);

        if (menu is null)
        {
            throw new NotFoundException(nameof(Menu), request.Id);
        }

        context.Menus.Remove(menu);
        await context.SaveChangesAsync(cancellationToken);
    }
}