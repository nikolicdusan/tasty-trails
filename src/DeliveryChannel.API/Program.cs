using DeliveryChannel.API.Middleware;
using DeliveryChannel.BusinessLogic;
using DeliveryChannel.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogic();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();