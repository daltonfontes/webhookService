using System;

namespace WebhookService.Api.Helpers.Routes;

public static class ApiRoutes
{
    public const string Base = "/";

    public const string Version = "v{api-version:apiVersion}";

    public const string Root = Base + Version;

    public static class HealthCheck
    {
        public const string Get = Base + "/HealthCheck";
    }

    public static class Webhook
    {
        public const string Post = Base + "/webhook";
    }
}
