using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Presentation.Middlewares;
public class ExceptionHandlingMiddleware(RequestDelegate _next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadHttpRequestException ex)
        {
            await HandleBadHttpRequestExceptionAsync(context, ex);
        }
    }

    private static Task HandleBadHttpRequestExceptionAsync(HttpContext context, BadHttpRequestException exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        ErrorResponse errorResponse = new()
        {
            Message = "Error in Request",
            Details = exception.Message
        };

        string json = JsonSerializer.Serialize(errorResponse);
        return context.Response.WriteAsync(json);
    }
}
