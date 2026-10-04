using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EcommerceApi.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var statusCode = exception switch
            {
                BadRequestException =>
                   StatusCodes.Status400BadRequest,

                NotFoundException =>
                   StatusCodes.Status404NotFound,

                ConcurrencyException =>
                   StatusCodes.Status409Conflict,

                _ =>
                   StatusCodes.Status500InternalServerError
            };

            if (statusCode == StatusCodes.Status500InternalServerError)
            {
                _logger.LogError(
                    exception,
                    "Unhandled exception occured");
            }

            string detail = statusCode == StatusCodes.Status500InternalServerError
                ? "An unexpected error occured."
                : exception.Message;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = GetTitle(statusCode),
                Detail = detail
            };

            httpContext.Response.StatusCode = statusCode;

            httpContext.Response.WriteAsJsonAsync(
                new
                {
                    problemDetails,
                    cancellationToken
                });


            return ValueTask.FromResult(true);


        }


        private static string GetTitle(int statusCode)
        {
            return statusCode switch
            {
                StatusCodes.Status400BadRequest =>
                 "Bad Request",

                StatusCodes.Status404NotFound =>
                 "Not Found",

                StatusCodes.Status409Conflict =>
                 "Conflicts",


                _ =>
                "Internal Server Error"
            };
        }
    }
}