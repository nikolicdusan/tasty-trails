using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.API.Controllers;

/// <summary>
/// A base class for Tasty Trails API controllers.
/// </summary>
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _sender;

    /// <summary>
    /// Provides access to the <see cref="ISender"/> service for sending commands and queries to the application.
    /// </summary>
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}