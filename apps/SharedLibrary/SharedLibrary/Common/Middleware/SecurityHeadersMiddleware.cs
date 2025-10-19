using Microsoft.AspNetCore.Http;

namespace SharedLibrary.Common.Middleware
{
    public class SecurityHeadersMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-Frame-Options"] = "DENY";
            context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
            await next(context);
        }
    }
}
