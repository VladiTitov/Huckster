namespace Selector.BackgroundTasks.TelegramService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITelegramBotService _telegramBotHandler;

        public Worker(ILogger<Worker> logger,
            ITelegramBotService telegramBotHandler)
        {
            _logger = logger;
            _telegramBotHandler = telegramBotHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _telegramBotHandler.StartReceiving(stoppingToken);
        }
    }
}