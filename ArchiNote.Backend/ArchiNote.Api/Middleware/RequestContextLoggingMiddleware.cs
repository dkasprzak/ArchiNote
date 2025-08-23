﻿using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace ArchiNote.Api.Middleware;

public class RequestContextLoggingMiddleware(RequestDelegate next)
{
    private const string CorrelationIdHeaderName = "Correlation-Id";


    public Task Invoke(HttpContext httpContext)
    {
        using (LogContext.PushProperty("CorrelationId", GetCorrelationId(httpContext)))
        {
            return next.Invoke(httpContext);
        }
    }
    
    private static string GetCorrelationId(HttpContext httpContext)
    {
        httpContext.Request.Headers.TryGetValue(
            CorrelationIdHeaderName, 
                out StringValues correlationId);
        
        return correlationId.FirstOrDefault() ?? httpContext.TraceIdentifier;
    }
}