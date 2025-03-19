using WebhookService.Domain.Entities;

namespace WebhookService.Domain.Interfaces
{
    public interface IWebhookRepository
    {
        Task SaveAsync(WebhookEvent webhookEvent);
        Task<List<WebhookEvent>> GetAsync();
    }
}
