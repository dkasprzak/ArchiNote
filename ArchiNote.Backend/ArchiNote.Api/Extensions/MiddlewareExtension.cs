using ArchiNote.Api.Middleware;

namespace ArchiNote.Api.Extensions;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextLoggingMiddleware>();
        
        return app;
    }
}