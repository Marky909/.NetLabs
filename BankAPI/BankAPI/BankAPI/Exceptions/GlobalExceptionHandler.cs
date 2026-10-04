using BankAPI.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception,
            "Error Occured:{Message}",
            exception.Message);

        var statusCode = exception switch
        {
            ArgumentException
            => StatusCodes.Status400BadRequest,

           

            InsufficientBalanceException =>
                StatusCodes.Status409Conflict,

            _ =>
                StatusCodes.Status500InternalServerError
        };

        var message = exception switch
        {
            ArgumentException =>
                exception.Message,

            InsufficientBalanceException =>
                exception.Message,

            _ =>
                "An unexpected error occurred."
        };

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = message
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(
            problem,
            cancellationToken);

        return true;
    }
    
}