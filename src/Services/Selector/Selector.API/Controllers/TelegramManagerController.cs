using Selector.Core.Application.Interfaces;

namespace Selector.API.Controllers
{
    public class TelegramManagerController : BaseController
    {
        private readonly ILogger<TelegramManagerController> _logger;
        private readonly ITelegramBotHandlerService _telegramBotService;

        public TelegramManagerController(
            ILogger<TelegramManagerController> logger,
            ITelegramBotHandlerService telegramBotService)
        {
            _logger = logger;
            _telegramBotService = telegramBotService;
        }

        [HttpPost]
        public async Task<IActionResult> StartService(
            string telegramToken,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("");
            await _telegramBotService.StartReceiving(telegramToken, cancellationToken);
            return Ok("");
        }

        [HttpGet]
        public async Task<IActionResult> StopService(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("");
            return Ok("");
        }

    }
}
