using System.Net;
using System.Text.Json;
using Domain.Exceptions;

namespace Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "An unhandled exception occurred.");

        context.Response.ContentType = "application/json";

        var statusCode = GetStatusCodeFromException(ex);

        context.Response.StatusCode = statusCode;

        var response = new
        {
            message = ex.Message,
            statusCode
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private int GetStatusCodeFromException(Exception ex)
    {
        return ex switch
        {
            NoEntitiesFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }
}