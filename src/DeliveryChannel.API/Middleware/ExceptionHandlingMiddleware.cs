using System.Net;
using DeliveryChannel.BusinessLogic.Common.Exceptions;
using DeliveryChannel.Domain.Exceptions;
using Newtonsoft.Json;

namespace DeliveryChannel.API.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            await HandleNotFoundException(context, ex);
        }
        catch (OverlappingMenuPeriodException ex)
        {
            await HandleOverlappingMenuPeriodException(context, ex);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleNotFoundException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;

        var errorResponse = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "The requested resource was not found.",
            Detail = exception.Message
        };

        return WriteResponse(context, errorResponse);
    }

    private static Task HandleOverlappingMenuPeriodException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

        var errorResponse = new
        {
            context.Response.StatusCode,
            Message = "Unable to process the request.",
            Detail = exception.Message
        };

        return WriteResponse(context, errorResponse);
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error",
            Detail = exception.Message
        };

        return WriteResponse(context, errorResponse);
    }

    private static Task WriteResponse(HttpContext context, object errorResponse) =>
        context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
}