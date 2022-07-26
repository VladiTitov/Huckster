using Microsoft.Extensions.Logging;

namespace TelegramService.Infrastructure.TelegramBot.Handlers
{
    internal class TelegramBotHandler : ITelegramBotHandler
    {
        private readonly ILogger<TelegramBotHandler> _logger;
        private readonly IMessageTelegramHandler _messageHandler;
        private readonly ICallbackQueryHandler _callbackQueryHandler;

        public TelegramBotHandler(
            ILogger<TelegramBotHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleErrorAsync(
            ITelegramBotClient botClient, 
            Exception exception, 
            CancellationToken cancellationToken = default)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogError(errorMessage);
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(
            ITelegramBotClient botClient, 
            Update update, 
            CancellationToken cancellationToken = default)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await _messageHandler.Handle(
                        message: update.Message,
                        cancellationToken: cancellationToken);
                    break;
                case UpdateType.CallbackQuery:
                    await _callbackQueryHandler.Handle(
                        callbackQuery: update.CallbackQuery,
                        cancellationToken: cancellationToken);
                    break;
            }
        }
    }
}
