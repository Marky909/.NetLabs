using System.Text.Json;
using EcommerceApi.Exceptions;

namespace EcommerceApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadRequestException ex)
        {
            await WriteResponse(
                context,
                StatusCodes.Status400BadRequest,
                ex.Message);
        }
        catch (ConcurrencyException ex)
        {
            await WriteResponse(
                context,
                StatusCodes.Status409Conflict,
                ex.Message);
        }
        catch (NotFoundException ex)
        {
            await WriteResponse(
                context,
                StatusCodes.Status404NotFound,
                ex.Message);
        }
    }

    private static async Task WriteResponse(
        HttpContext context,
        int statusCode,
        string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            statusCode,
            message
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}