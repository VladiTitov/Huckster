using TelegramService.Core.Application.Interfaces;

namespace TelegramService.Core.Application.Services
{
    public class TelegramBotManageService : ITelegramBotManageService
    {
        private readonly ITelegramBotService _telegramBotService;

        public TelegramBotManageService(
            ITelegramBotService telegramBotService)
        {
            _telegramBotService = telegramBotService;
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            await _telegramBotService.ReceiveAsync(cancellationToken);
        }
    }
}
