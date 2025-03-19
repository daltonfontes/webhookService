using System.Diagnostics.Metrics;
using Prometheus;

namespace WebhookService.Application.Services
{
    public class MetricsService
    {

        private static readonly Counter _webhookRequestsCounter = Metrics
            .CreateCounter("webhook_requests_total", "Total number of webhook requests received");
        private static readonly Histogram _webhookResponseTime = Metrics
            .CreateHistogram("webhook_response_time_seconds", "Time taken to process webhook requests");

        public static void IncrementWebhookRequestsCounter()
        {
            _webhookRequestsCounter.Inc();
        }

        public static IDisposable StartWebhookTimer()
        {
            return _webhookResponseTime.NewTimer();
        }
    }
}
