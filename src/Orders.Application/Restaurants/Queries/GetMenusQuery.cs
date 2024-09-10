using MediatR;
using Orders.Application.Restaurants.DTOs;

namespace Orders.Application.Restaurants.Queries;

public record GetMenusQuery(int RestaurantId) : IRequest<RestaurantMenusDto>;