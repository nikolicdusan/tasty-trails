using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurants;

public record GetRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>;

