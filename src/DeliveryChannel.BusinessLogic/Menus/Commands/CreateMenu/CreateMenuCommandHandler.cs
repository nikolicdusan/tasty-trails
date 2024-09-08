using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.Domain.Entities;
using DeliveryChannel.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryChannel.BusinessLogic.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler(IRestaurantDbContext context) : IRequestHandler<CreateMenuCommand, long>
{
    public async Task<long> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = new Menu
        {
            RestaurantId = request.RestaurantId,
            Title = request.Title,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        var overlappingMenu = await context.Menus
            .Where(e => e.RestaurantId == request.RestaurantId)
            .Where(e => request.StartDate < e.EndDate && e.StartDate < request.EndDate)
            .FirstOrDefaultAsync(cancellationToken);

        if (overlappingMenu is not null)
        {
            throw new OverlappingMenuPeriodException(request.StartDate, request.EndDate);
        }

        context.Menus.Add(menu);
        await context.SaveChangesAsync(cancellationToken);

        return menu.Id;
    }
}