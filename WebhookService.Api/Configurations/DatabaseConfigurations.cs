using Microsoft.EntityFrameworkCore;
using WebhookService.Infrastructure.Context;
namespace WebhookService.Api.Configurations
{
    public static class DatabaseConfigurations
    {
        public static void RunMigration(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<DataContext>();

                dbContext.Database.Migrate();
            }
        }
    }
}
