namespace Selector.BackgroundTasks.TelegramService.Services
{
    internal class TelegramBotHandlerService : ITelegramBotHandlerService
    {
        private ITelegramBotClient _telegramBotClient;
        private readonly IErrorTelegramHandler _errorHandler;
        private readonly IUpdateTelegramHandler _updateHandler;
        private readonly ILogger<TelegramBotHandlerService> _logger;

        public TelegramBotHandlerService(
            ILogger<TelegramBotHandlerService> logger,
            IErrorTelegramHandler errorHandler,
            IUpdateTelegramHandler updateHandler)
        {
            _logger = logger;
            _errorHandler = errorHandler;
            _updateHandler = updateHandler;
        }

        public Task StartReceiving(
            string telegramToken,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _telegramBotClient = new TelegramBotClient(token: telegramToken);
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            _logger.LogInformation("Telegram bot service was started");

            _telegramBotClient.StartReceiving(
                updateHandler: _updateHandler.HandleUpdateAsync,
                errorHandler: _errorHandler.HandleErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken);

            return Task.CompletedTask;
        }
    }
}
