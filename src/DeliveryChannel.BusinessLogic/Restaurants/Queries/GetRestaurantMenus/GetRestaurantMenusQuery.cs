using DeliveryChannel.BusinessLogic.Restaurants.Models;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantMenus;

public record GetRestaurantMenusQuery(long RestaurantId) : IRequest<IEnumerable<RestaurantMenuDto>>;