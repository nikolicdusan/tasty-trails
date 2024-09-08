using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.Domain.Entities;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IRestaurantDbContext context) : IRequestHandler<CreateRestaurantCommand, long>
{
    public async Task<long> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = new Restaurant
        {
            Name = request.Name,
            Country = request.Country,
            City = request.City,
            AddressLine = request.AddressLine
        };

        context.Restaurants.Add(restaurant);
        await context.SaveChangesAsync(cancellationToken);

        return restaurant.Id;
    }
}