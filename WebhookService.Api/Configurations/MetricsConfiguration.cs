using Prometheus;

namespace WebhookService.Api.Configurations;

public static class MetricsConfiguration
{
    public static void ConfigureMetrics(this IApplicationBuilder app)
    {
        app.UseHttpMetrics();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapMetrics();
        });
    }
}
