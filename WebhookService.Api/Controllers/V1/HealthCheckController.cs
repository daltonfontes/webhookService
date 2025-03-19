using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebhookService.Api.Helpers.Routes;

namespace WebhookService.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet(ApiRoutes.HealthCheck.Get)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
