using Microsoft.EntityFrameworkCore;
using WebhookService.Domain.Entities;
using WebhookService.Domain.Interfaces;
using WebhookService.Infrastructure.Context;

namespace WebhookService.Infrastructure.Repositories
{
    public class InMemoryWebhookRepository : IWebhookRepository
    {
        private readonly DataContext _dbContext;

        public InMemoryWebhookRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(WebhookEvent webhookEvent)
        {
            await _dbContext.WebhookEvents.AddAsync(webhookEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<WebhookEvent>> GetAsync()
        {
            return await _dbContext.WebhookEvents.ToListAsync();
        }
    }
}
