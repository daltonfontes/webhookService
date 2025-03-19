using Microsoft.AspNetCore.Mvc;
using WebhookService.Application.UseCases;

namespace WebhookService.Api.Controllers;

[ApiController]
[Route("api/webhook")]
public class WebhookController : ControllerBase
{
    private readonly ProcessWebhookUseCase _processWebhookUseCase;

    public WebhookController(ProcessWebhookUseCase processWebhookUseCase)
    {
        _processWebhookUseCase = processWebhookUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WebhookEventDto webhookEventDto)
    {
        await _processWebhookUseCase.ExecuteAsync(webhookEventDto.Type, webhookEventDto.Payload);
        return Ok();
    }
}
