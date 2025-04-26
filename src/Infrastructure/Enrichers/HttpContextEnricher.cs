using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System.Security.Claims;

namespace Infrastructure.Enrichers;

public class HttpContextEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextEnricher(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext == null)
            return;

        var ip = httpContext.Connection.RemoteIpAddress?.ToString();
        var userId = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userName = httpContext.User?.Identity?.Name;

        if (!string.IsNullOrWhiteSpace(ip))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ClientIp", ip));

        if (!string.IsNullOrWhiteSpace(userId))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserId", userId));

        if (!string.IsNullOrWhiteSpace(userName))
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", userName));
    }
}
