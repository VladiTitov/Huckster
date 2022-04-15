using Microsoft.Extensions.Logging;
using CustomBackgroundService.Manager;
using Selector.Infrastructure.TelagramWorker.Interfaces;
using Selector.Core.Application.Features.Telegram.Interfaces;

namespace Selector.Core.Application.Features.Telegram
{
    public class TelegramBackgroundServiceManager : BackgroundServiceManager, ITelegramBackgroundServiceManager
    {
        private readonly ILogger<TelegramBackgroundServiceManager> _logger;
        private readonly ITelegramBotService _telegramBotService;

        public TelegramBackgroundServiceManager(ILogger<TelegramBackgroundServiceManager> logger,
            ITelegramBotService telegramBotService)
            : base(logger)
        {
            _logger = logger;
            _telegramBotService = telegramBotService;
        }

        protected override async void Execute(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Telegram service started!");
             await _telegramBotService.StartReceiving(cancellationToken: cancellationToken);
        }
    }
}
