using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Restaurants.DTOs;

namespace Orders.Application.Restaurants.Queries;

public class GetMenuByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetMenuByIdQuery, MenuDto>
{
    public async Task<MenuDto> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
    {
        var menu = await context.Menus
            .Include(m => m.MenuItems)
            .FirstOrDefaultAsync(m => m.RestaurantId == request.RestaurantId && m.Id == request.MenuId,
                cancellationToken);

        if (menu is null)
        {
            throw new NotFoundException(nameof(Menu), $"restaurantId: {request.RestaurantId}, menuId: {request.MenuId}");
        }

        return new MenuDto
        {
            Id = menu.Id,
            RestaurantId = menu.RestaurantId,
            Name = menu.Name,
            Description = menu.Description,
            AvailableFrom = menu.AvailableFrom,
            AvailableUntil = menu.AvailableUntil,
            CreatedAt = menu.CreatedAt,
            LastUpdatedAt = menu.LastUpdatedAt,
            MenuItems = menu.MenuItems?.Select(mi => new MenuItemDto
            {
                Id = mi.Id,
                Name = mi.Name,
                Description = mi.Description,
                Price = mi.Price,
                Category = mi.Category.ToString(),
                IsAvailable = mi.IsAvailable
            }).ToList()
        };
    }
}