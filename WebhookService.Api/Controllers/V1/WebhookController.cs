using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebhookService.Api.Dto;
using WebhookService.Api.Helpers.Routes;
using WebhookService.Application.Services;
using WebhookService.Application.UseCases;

namespace WebhookService.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
public class WebhookController : ControllerBase
{
    private readonly ProcessWebhookUseCase _processWebhookUseCase;
    private readonly MetricsService _metricsService;

    public WebhookController(ProcessWebhookUseCase processWebhookUseCase, MetricsService metricsService)
    {
        _processWebhookUseCase = processWebhookUseCase;
        _metricsService = metricsService;
    }

    [HttpPost(ApiRoutes.Webhook.Post)]
    public async Task<IActionResult> Post([FromBody] WebhookEventDto webhookEventDto)
    {
        if (webhookEventDto == null)
        {
            return BadRequest(new { status = "Bad Request", success = false });
        }

        using (MetricsService.StartWebhookTimer())
        {
            MetricsService.IncrementWebhookRequestsCounter();
            await _processWebhookUseCase.ExecuteAsync(webhookEventDto.Type, webhookEventDto.Payload);
        }

        return Ok(new { status = "Ok", success = true });
    }
}
