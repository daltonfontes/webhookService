namespace WebhookService.Domain.Entities;

public class WebhookEvent
{
    public Guid Id { get; set; }

    public string Type { get; private set; }

    public string Payload { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public WebhookEvent(string type, string payload)
    {
        Id = Guid.NewGuid();
        Type = type;
        Payload = payload;
        CreatedAt = DateTime.UtcNow;
    }
}
