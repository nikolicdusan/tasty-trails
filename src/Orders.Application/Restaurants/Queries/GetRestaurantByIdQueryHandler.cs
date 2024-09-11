using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;
using MediatR;
using Orders.Application.Restaurants.DTOs;

namespace Orders.Application.Restaurants.Queries;

public class GetRestaurantByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await context.Restaurants
            .FindAsync(new object?[] { request.Id }, cancellationToken);

        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id);
        }

        return new RestaurantDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Country = restaurant.Country,
            City = restaurant.City,
            Address = restaurant.Address ?? string.Empty,
            CuisineType = restaurant.CuisineType.ToString()
        };
    }
}