using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SharedLibrary.Common.Middleware
{
    public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
    {
        private const int WarningThresholdMs = 3000;
        private const int ErrorThresholdMs = 6000;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            await next.Invoke(context);
            stopWatch.Stop();

            string traceId = context.TraceIdentifier;
            string userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "anonymous";
            string statusCode = context.Response.StatusCode.ToString();

            if (stopWatch.ElapsedMilliseconds > WarningThresholdMs)
            {
                logger.LogWarning("Slow request detected: {Method} {Path} took {ElapsedMilliseconds} ms | StatusCode: {StatusCode} | UserId: {UserId} | TraceId: {TraceId}",
                    context.Request.Method,
                    context.Request.Path,
                    stopWatch.ElapsedMilliseconds,
                    statusCode,
                    userId,
                    traceId);
            }

            if (stopWatch.ElapsedMilliseconds > ErrorThresholdMs)
            {
                logger.LogWarning("Slow or failed request: {Method} {Path} took {ElapsedMilliseconds} ms | StatusCode: {StatusCode} | UserId: {UserId} | TraceId: {TraceId}",
                    context.Request.Method,
                    context.Request.Path,
                    stopWatch.ElapsedMilliseconds,
                    statusCode,
                    userId,
                    traceId);
            }
        }
    }
}
