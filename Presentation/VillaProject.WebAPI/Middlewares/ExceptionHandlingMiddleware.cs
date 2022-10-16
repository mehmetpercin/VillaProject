using System.Net;
using System.Text.Json;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Domain.Exceptions;

namespace VillaProject.WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
            context.Response.ContentType = "application/json";

            _logger.LogError(message: exception.InnerException?.Message ?? exception.Message);
            ErrorResponse response = exception switch
            {
                IdentityException => ErrorResponse.Fail(exception.Message, 400),
                DatabaseValidationException => ErrorResponse.Fail(exception.Message, 400),
                _ => ErrorResponse.Fail("An error occured!", context.Response.StatusCode),
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
