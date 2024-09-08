using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.BusinessLogic.Common.Interfaces;
using DeliveryChannel.Domain.Entities;
using MediatR;

namespace DeliveryChannel.BusinessLogic.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IRestaurantDbContext context) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await context.Restaurants
            .FindAsync(request.Id, cancellationToken);

        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id);
        }

        context.Restaurants.Remove(restaurant);
        await context.SaveChangesAsync(cancellationToken);
    }
}