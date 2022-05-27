namespace Selector.BackgroundTasks.TelegramService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITelegramBotHandlerService _telegramBotHandler;

        public Worker(ILogger<Worker> logger,
            ITelegramBotHandlerService telegramBotHandler)
        {
            _logger = logger;
            _telegramBotHandler = telegramBotHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string token = "5234612082:AAHEthD2BBF0Kkd1Q72ap9cLyTsVFBLqlcA";
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _telegramBotHandler.StartReceiving(
                telegramToken: token,
                cancellationToken: stoppingToken);
        }
    }
}