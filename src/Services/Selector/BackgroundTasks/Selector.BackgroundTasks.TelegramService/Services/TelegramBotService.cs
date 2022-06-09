using EventBus.RabbitMq.Interfaces;

namespace Selector.BackgroundTasks.TelegramService.Services
{
    internal class TelegramBotService : ITelegramBotService
    {
        private readonly ILogger<TelegramBotService> _logger;
        private readonly ITelegramBotContext _telegramBotContext;
        private readonly ITelegramBotHandler _telegramBotHandler;
        private readonly IRabbitMqSubscriber _eventBusSubscriber;

        public TelegramBotService(
            ILogger<TelegramBotService> logger,
            ITelegramBotHandler telegramBotHandler,
            ITelegramBotContext telegramBotContext,
            IRabbitMqSubscriber eventBusSubscriber)
        {
            _logger = logger;
            _telegramBotHandler = telegramBotHandler;
            _telegramBotContext = telegramBotContext;
            _eventBusSubscriber = eventBusSubscriber;
        }

        public Task StartReceiving(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("Telegram bot service was started");

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            _telegramBotContext.BotClient.StartReceiving(
                updateHandler: _telegramBotHandler.HandleUpdateAsync,
                errorHandler: _telegramBotHandler.HandleErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken);

            _logger.LogInformation("EventBus subscriber started");
            _eventBusSubscriber.StartService();

            return Task.CompletedTask;
        }
    }
}