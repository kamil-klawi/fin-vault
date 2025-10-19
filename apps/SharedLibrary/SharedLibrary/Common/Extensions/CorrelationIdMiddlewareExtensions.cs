using Microsoft.AspNetCore.Builder;
using SharedLibrary.Common.Middleware;

namespace SharedLibrary.Common.Extensions
{
    public static class CorrelationIdMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationIdMiddleware>();
        }
    }
}
