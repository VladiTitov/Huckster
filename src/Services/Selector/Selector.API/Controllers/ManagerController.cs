using Microsoft.AspNetCore.Mvc;
using Selector.Core.Application.Features.Telegram.Interfaces;

namespace Selector.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly ITelegramBackgroundServiceManager _telegramServiceManager;

        public ManagerController(ILogger<ManagerController> logger,
            ITelegramBackgroundServiceManager telegramServiceManager)
        {
            _logger = logger;
            _telegramServiceManager = telegramServiceManager;
        }

        [HttpGet]
        [Route("StartTelegramService")]
        public async Task<IActionResult> StartTelegramService()
        {
            _logger.LogInformation("");
            await _telegramServiceManager.StartAsync(new CancellationToken());
            return Ok("");
        }

        [HttpGet]
        [Route("StopTelegramService")]
        public async Task<IActionResult> StopTelegramService()
        {
            _logger.LogInformation("");
            await _telegramServiceManager.StopAsync(new CancellationToken());
            return Ok("");
        }


        [HttpGet]
        [Route("StartSelectorService")]
        public async Task<IActionResult> StartSelectorService()
        {
            _logger.LogInformation("");
            return Ok("");
        }

        [HttpGet]
        [Route("StopSelectorService")]
        public async Task<IActionResult> StopSelectorService()
        {
            _logger.LogInformation("");
            return Ok("");
        }
    }
}
