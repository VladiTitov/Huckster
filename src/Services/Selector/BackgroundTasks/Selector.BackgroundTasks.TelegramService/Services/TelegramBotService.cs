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
            _telegramClient = GetTelegramBotClient(token);
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

        private ITelegramBotClient GetTelegramBotClient(string token)
        {
            Guard.Against.NullOrEmpty(token, nameof(token));
            var botClient = new TelegramBotClient(token);
            Guard.Against.CanConnect(botClient, nameof(token));
            return botClient;
        }
    }
}
