using System;

namespace WebhookService.Domain.Responses;

public interface IResponse
{
    public bool Success { get; }
}
