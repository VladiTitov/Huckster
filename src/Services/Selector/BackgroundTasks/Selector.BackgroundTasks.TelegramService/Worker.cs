namespace Selector.BackgroundTasks.TelegramService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITelegramBotHandlerService _telegramBotHandler;
        private readonly string _token;

        public Worker(ILogger<Worker> logger,
            ITelegramBotHandlerService telegramBotHandler,
            IConfiguration configuration)
        {
            _logger = logger;
            _telegramBotHandler = telegramBotHandler;
            _token = configuration.GetTelegramToken();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_token is null) throw new ArgumentNullException(nameof(_token));
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _telegramBotHandler.StartReceiving(
                telegramToken: _token,
                cancellationToken: stoppingToken);
        }
    }
}