using System;
using Microsoft.EntityFrameworkCore;
using WebhookService.Domain.Entities;

namespace WebhookService.Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<WebhookEvent> WebhookEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WebhookEvent>()
            .HasIndex(x => x.Type)
            .IsUnique();
    }
}
