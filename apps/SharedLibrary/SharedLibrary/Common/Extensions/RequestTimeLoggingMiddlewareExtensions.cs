using Microsoft.AspNetCore.Builder;
using SharedLibrary.Common.Middleware;

namespace SharedLibrary.Common.Extensions
{
    public static class RequestTimeLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimeLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeLoggingMiddleware>();
        }
    }
}
