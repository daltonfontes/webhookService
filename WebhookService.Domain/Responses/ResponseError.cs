using System;

namespace WebhookService.Domain.Responses;

public class ResponseError<T> : IResponse
{
    public bool Success { get; private set; } = false;

    public T Error { get; set; }
}

public class ResponseError : IResponse
{
    public bool Success { get; private set; } = false;

    public string Error { get; set; }
}

public class ResponseBadRequestError : ResponseError { }

public class ResponseConflictError : ResponseError { }

public class ResponseNotFoundError : ResponseError { }
