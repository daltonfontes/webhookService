using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebhookService.Api.Dto;
using WebhookService.Api.Helpers.Routes;
using WebhookService.Application.UseCases;

namespace WebhookService.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
public class WebhookController : ControllerBase
{
    private readonly ProcessWebhookUseCase _processWebhookUseCase;

    public WebhookController(ProcessWebhookUseCase processWebhookUseCase)
    {
        _processWebhookUseCase = processWebhookUseCase;
    }

    [HttpPost(ApiRoutes.Webhook.Post)]
    public async Task<IActionResult> Post([FromBody] WebhookEventDto webhookEventDto)
    {
        await _processWebhookUseCase.ExecuteAsync(webhookEventDto.Type, webhookEventDto.Payload);
        return Ok(new { status = "Ok", success = true });
    }
}
