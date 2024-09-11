using System.Net;
using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Web;

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
            context.Response.StatusCode,
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
            context.Response.StatusCode,
            Message = "Internal Server Error",
            Detail = exception.Message
        };

        return WriteResponse(context, errorResponse);
    }

    private static Task WriteResponse(HttpContext context, object errorResponse) =>
        context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
}