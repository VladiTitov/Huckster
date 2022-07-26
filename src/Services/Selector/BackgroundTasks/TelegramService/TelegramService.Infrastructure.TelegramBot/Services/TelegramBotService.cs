using Microsoft.Extensions.Logging;

namespace TelegramService.Infrastructure.TelegramBot.Services
{
    internal class TelegramBotService : ITelegramBotService
    {
        private readonly ILogger<TelegramBotService> _logger;
        private readonly ITelegramBotHandler _telegramBotHandler;
        private readonly ITelegramBotServiceClientWrapper _telegramBotClientWrapper;

        public TelegramBotService(
            ILogger<TelegramBotService> logger,
            ITelegramBotHandler telegramBotHandler,
            ITelegramBotServiceClientWrapper telegramBotClientWrapper)
        {
            _logger = logger;
            _telegramBotHandler = telegramBotHandler;
            _telegramBotClientWrapper = telegramBotClientWrapper;
        }

        public async Task ReceiveAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Telegram bot service was started");

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            await _telegramBotClientWrapper.ReceiveAsync(
                updateHandler: _telegramBotHandler.HandleUpdateAsync,
                errorHandler: _telegramBotHandler.HandleErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken);
        }

        public async Task SendTextMessageAsync(
            long chatId, 
            string text, 
            CancellationToken cancellationToken = default)
        {
            await _telegramBotClientWrapper.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                cancellationToken: cancellationToken);
        }
    }
}
