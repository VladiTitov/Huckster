namespace TelegramService.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITelegramBotManageService _telegramBotManageService;

        public Worker(
            ILogger<Worker> logger, 
            ITelegramBotManageService telegramBotManageService)
        {
            _logger = logger;
            _telegramBotManageService = telegramBotManageService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _telegramBotManageService.StartAsync(cancellationToken);
        }
    }
}