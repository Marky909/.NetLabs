using Microsoft.AspNetCore.Diagnostics;

namespace BankApi.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        Console.WriteLine(exception.Message);

        return true;
    }
}