using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.BusinessLogic.Common.Mappers;
using DeliveryChannel.BusinessLogic.Restaurants.Models;
using DeliveryChannel.Domain.Entities;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(IRestaurantDbContext context) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await context.Restaurants
            .FindAsync(new object?[] { request.Id }, cancellationToken);

        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id);
        }

        return restaurant.ToRestaurantDto();
    }
}