using WebhookService.Domain.Entities;
using WebhookService.Domain.Interfaces;

namespace WebhookService.Infrastructure.Repositories
{
    public class InMemoryWebhookRepository : IWebhookRepository
    {
        private readonly List<WebhookEvent> _webhookEvents = new List<WebhookEvent>();

        public Task SaveAsync(WebhookEvent webhookEvent)
        {
            _webhookEvents.Add(webhookEvent);
            return Task.CompletedTask;
        }

        public Task<List<WebhookEvent>> GetAsync()
        {
            return Task.FromResult(_webhookEvents.ToList());
        }
    }
}
