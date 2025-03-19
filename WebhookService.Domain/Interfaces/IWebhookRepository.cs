using WebhookService.Domain.Entities;
using WebhookService.Domain.Responses;

namespace WebhookService.Domain.Interfaces
{
    public interface IWebhookRepository
    {
        Task SaveAsync(WebhookEvent webhookEvent);
        Task<List<WebhookEvent>> GetAsync();
    }
}
