using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Commands.DeleteRestaurant;

public record DeleteRestaurantCommand(long Id) : IRequest;
