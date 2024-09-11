# Tasty Trails
Tasty Trails is a restaurant chain that offers in-restaurant food ordering, as well as ordering online via 3rd party channels.

## Overview

This repository contains the implementation of an API for online food ordering, developed using .NET 8. The API integrates with a PostgreSQL database to manage data, and it uses Swagger for API documentation and testing.

## Features

- **Order Management**: Create, update, and track orders.
- **Cart Management**: Add and remove items from the cart.
- **Payment Processing**: Handle payment via external gateway integration.
- **Restaurant Management**: Retrieve restaurant and menu information.
- **Swagger Documentation**: Interactive API documentation for testing and exploring the endpoints.

## Technologies

- **.NET 8**: Framework for building and running the API.
- **Entity Framework Core**: ORM framework for data access management.
- **PostgreSQL**: Database for storing data related to restaurants, menus, orders, and users.
- **Swagger**: API documentation and testing tool integrated into the project.

## Setup

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Install Dependencies
```bash
dotnet restore
```

### Configure the Database
The application can be configured to use either an in-memory database (for testing) or a PostgreSQL database (for production).

In the appsettings.json file, you can configure the following options:

```json
{
  "UseInMemoryDatabase": true, // Set to true for in-memory database, false for PostgreSQL
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=FoodOrderingDb;Username=youruser;Password=yourpassword"
  }
}
```

- If UseInMemoryDatabase is set to true, the application will use an in-memory database. This is useful for local testing or development.
- If UseInMemoryDatabase is set to false, ensure that you have a PostgreSQL instance running and update the DefaultConnection string with your PostgreSQL connection details.

#### Database Seeding

The application includes database seeding to populate some initial data. This is triggered automatically on startup if the database is empty.

### Run the API

```bash
dotnet run
```

### Access Swagger
Once the application is running, you can access Swagger UI at:

```bash
http://localhost:5000/swagger
```
Use Swagger UI to interact with the API endpoints and test various operations.

## API Endpoints
## Order Management
- `POST /api/orders/checkout`: Place an order.
- `GET /api/orders/{orderId}/status`: Get the status of an order.
### Cart Management
- `POST /api/orders/cart/items`: Add an item to the cart.
- `DELETE /api/orders/cart/items/{itemId}`: Remove an item from the cart.
### Payment Processing
- `POST /api/payment/callback`: Handle payment callback.
### Restaurant Management
- `GET /api/restaurants`: Get all restaurants.
- `GET /api/restaurants/{restaurantId}`: Get a restaurant by ID.
- `GET /api/restaurants/{restaurantId}/menus`: Get all menus for a restaurant.
- `GET /api/restaurants/{restaurantId}/menus/{menuId}`: Get a menu by ID.