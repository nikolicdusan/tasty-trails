using MediatR;
using Orders.Application.Restaurants.DTOs;

namespace Orders.Application.Restaurants.Queries;

public record GetMenuByIdQuery(int RestaurantId, int MenuId) : IRequest<MenuDto>;
