using System.ComponentModel.DataAnnotations;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Commands.CreateRestaurant;

public record CreateRestaurantCommand : IRequest<long>
{
    public required string Name { get; init; }
    [AllowedValues("Serbia")]
    public required string Country { get; init; }
    [AllowedValues("Belgrade", "Novi Sad", "Niš", "Subotica")]
    public required string City { get; init; }
    public required string AddressLine { get; init; }
}