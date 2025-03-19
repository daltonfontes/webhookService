using Asp.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebhookService.Api.Configurations.Swagger;

namespace WebhookService.Api.Configurations
{
    public static class VersionConfigurations
    {
        public static void AddVersionConfiguration(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
                .AddMvc()
                .AddApiExplorer(x =>
                {
                    x.GroupNameFormat = "'v'VVV";
                    x.SubstituteApiVersionInUrl = true;
                }
            );

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerApiVersionConfiguration>();
        }
    }
}
