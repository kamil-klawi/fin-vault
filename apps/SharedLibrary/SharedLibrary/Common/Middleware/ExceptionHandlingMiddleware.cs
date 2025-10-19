using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SharedLibrary.Common.Exceptions;
using SharedLibrary.Contracts.Common;
using TimeoutException = System.TimeoutException;

namespace SharedLibrary.Common.Middleware
{
    public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (UnauthorizedException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized);
            }
            catch (ForbiddenException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.Forbidden);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
            }
            catch (TimeoutException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.RequestTimeout);
            }
            catch (ConflictException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.Conflict);
            }
            catch (TooManyRequestsException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.TooManyRequests);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, "Unexpected error occurred.");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode, string? overrideMessage = null)
        {
            logger.LogWarning(exception, exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            ErrorResponse response = new ErrorResponse
            {
                Message = overrideMessage ?? exception.Message,
                StatusCode = exception.GetType().Name,
                Timestamp = DateTime.UtcNow
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}
