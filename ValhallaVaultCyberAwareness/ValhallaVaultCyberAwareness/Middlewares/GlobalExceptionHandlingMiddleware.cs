using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ValhallaVaultCyberAwareness.Middlewares
{
    /// <summary>
    /// This middleware intercepts exceptions, logs them, and sends a JSON-formatted error response to the client.
    /// </summary>
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleCustomExceptionResponseAsync(context, e);
            }
        }

        private async Task HandleCustomExceptionResponseAsync(HttpContext context, Exception e)
        {
            // Specify the content type of the incoming request as JSON
            context.Response.ContentType = MediaTypeNames.Application.Json;

            // Set the statuscode to 500
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Create a ProblemDetails model and set its properties to valuable information about the exception
            // Including StackTrace (if avaliable)
            var response = new ProblemDetails
            {
                Status = context.Response.StatusCode,
                Type = "Server error",
                Title = e.Message,
                Detail = e.StackTrace?.ToString()
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}
