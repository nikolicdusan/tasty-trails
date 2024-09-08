using DeliveryChannel.BusinessLogic.Restaurants.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurants;

public record GetRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>;

