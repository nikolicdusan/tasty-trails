using MediatR;
using Orders.Application.Restaurants.DTOs;

namespace Orders.Application.Restaurants.Queries;

public record GetRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>;