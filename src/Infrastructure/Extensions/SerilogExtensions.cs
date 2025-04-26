using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Enrichers;

namespace Infrastructure.Extensions;

public static class SerilogExtensions
{
    public static void AddCustomSerilog(this ILoggingBuilder builder)
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithEnvironmentUserName()
        .Enrich.WithMachineName()
            .Enrich.With(new HttpContextEnricher(httpContextAccessor))
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Information()
            .CreateLogger();
    }

    public static void UseSerilogRequestLoggingMiddleware(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging(options =>
        {
            options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
        });
    }
}
