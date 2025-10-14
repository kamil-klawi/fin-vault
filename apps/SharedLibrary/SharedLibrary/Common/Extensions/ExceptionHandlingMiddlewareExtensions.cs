using Microsoft.AspNetCore.Builder;
using SharedLibrary.Common.Middleware;

namespace SharedLibrary.Common.Extensions
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
