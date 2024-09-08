using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Common.Mappers;
using DeliveryChannel.BusinessLogic.Menus.Models;
using DeliveryChannel.Domain.Entities;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Menus.Queries.GetMenuById;

public class GetMenuByIdQueryHandler(IRestaurantDbContext context) : IRequestHandler<GetMenuByIdQuery, MenuDto>
{
    public async Task<MenuDto> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
    {
        var menu = await context.Menus
            .FindAsync(new object?[] { request.Id }, cancellationToken);

        if (menu is null)
        {
            throw new NotFoundException(nameof(Menu), request.Id);
        }

        return menu.ToMenuDto();
    }
}