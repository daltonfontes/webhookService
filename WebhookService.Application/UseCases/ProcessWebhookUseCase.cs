using WebhookService.Domain.Entities;
using WebhookService.Domain.Interfaces;

namespace WebhookService.Application.UseCases
{
    public class ProcessWebhookUseCase
    {
        private readonly IWebhookRepository _webhookRepository;

        public ProcessWebhookUseCase(IWebhookRepository webhookRepository)
        {
            _webhookRepository = webhookRepository;
        }

        public async Task ExecuteAsync(string type, string payload)
        {
            var webhookEvent = new WebhookEvent(type, payload);
            await _webhookRepository.SaveAsync(webhookEvent);
        }
    }
}
