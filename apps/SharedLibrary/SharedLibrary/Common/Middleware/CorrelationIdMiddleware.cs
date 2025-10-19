using Microsoft.AspNetCore.Http;

namespace SharedLibrary.Common.Middleware
{
    public class CorrelationIdMiddleware : IMiddleware
    {
        private const string HeaderName = "X-Correlation-ID";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.TryGetValue(HeaderName, out var correlationId))
                correlationId = Guid.NewGuid().ToString();

            context.Items[HeaderName] = correlationId;
            context.Response.Headers[HeaderName] = correlationId;

            await next(context);
        }
    }
}
