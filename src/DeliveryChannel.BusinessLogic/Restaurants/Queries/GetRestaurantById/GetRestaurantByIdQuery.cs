using DeliveryChannel.BusinessLogic.Restaurants.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantById;

public record GetRestaurantByIdQuery(long Id) : IRequest<RestaurantDto>;