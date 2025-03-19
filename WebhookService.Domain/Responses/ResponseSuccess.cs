namespace WebhookService.Domain.Responses;
public class ResponseSuccess<T> : ResponseSuccess
{
    public T Data { get; set; }
}

public class ResponseSuccess : IResponse
{
    public bool Success { get; private set; } = true;
}
