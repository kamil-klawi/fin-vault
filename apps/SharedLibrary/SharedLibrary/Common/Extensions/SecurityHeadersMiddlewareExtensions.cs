using Microsoft.AspNetCore.Builder;
using SharedLibrary.Common.Middleware;

namespace SharedLibrary.Common.Extensions
{
    public static class SecurityHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecurityHeadersMiddleware>();
        }
    }
}
