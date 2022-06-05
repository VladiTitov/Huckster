namespace Selector.BackgroundTasks.TelegramService.Services
{
    internal class TelegramBotService : ITelegramBotService
    {
        private readonly ILogger<TelegramBotService> _logger;
        private readonly ITelegramBotClient _telegramClient;
        private readonly ITelegramBotHandler _telegramBotHandler;
        
        public TelegramBotService(
            ILogger<TelegramBotService> logger,
            ITelegramBotHandler telegramBotHandler,
            IConfiguration configuration)
        {
            _logger = logger;
            _telegramBotHandler = telegramBotHandler;
            string token = configuration.GetTelegramToken();
            _telegramClient = token.GetTelegramBotClient();
        }

        public Task StartReceiving(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("Telegram bot service was started");

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            _telegramClient.StartReceiving(
                updateHandler: _telegramBotHandler.HandleUpdateAsync,
                errorHandler: _telegramBotHandler.HandleErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken);

            return Task.CompletedTask;
        }
    }
}
