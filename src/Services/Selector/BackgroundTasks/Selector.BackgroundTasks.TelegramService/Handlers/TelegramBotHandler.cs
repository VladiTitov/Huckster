namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class TelegramBotHandler : ITelegramBotHandler
    {
        private readonly ILogger<TelegramBotHandler> _logger;
        private readonly IMessageTelegramHandler _messageHandler;
        private readonly ICallbackQueryHandler _callbackQueryHandler;

        public TelegramBotHandler(
            ILogger<TelegramBotHandler> logger,
            IMessageTelegramHandler messageHandler,
            ICallbackQueryHandler callbackQueryHandler)
        {
            _logger = logger;
            _messageHandler = messageHandler;
            _callbackQueryHandler = callbackQueryHandler;
        }

        public async Task HandleUpdateAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await _messageHandler.Handle(
                        botClient: botClient,
                        message: update.Message,
                        cancellationToken: cancellationToken);
                    break;
                case UpdateType.CallbackQuery:
                    await _callbackQueryHandler.Handle(
                        botClient: botClient,
                        callbackQuery: update.CallbackQuery,
                        cancellationToken: cancellationToken);
                    break;
            }
        }

        public Task HandleErrorAsync(
            ITelegramBotClient botClient,
            Exception exception,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogError(errorMessage);
            return Task.CompletedTask;
        }
    }
}
