using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryChannel.API.Common;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _sender;

    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}