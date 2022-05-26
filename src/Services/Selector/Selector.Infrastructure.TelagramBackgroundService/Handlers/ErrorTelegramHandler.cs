namespace Selector.Infrastructure.TelagramBackgroundService.Handlers
{
    public class ErrorTelegramHandler : IErrorTelegramHandler
    {
        private readonly ILogger<ErrorTelegramHandler> _logger;

        public ErrorTelegramHandler(ILogger<ErrorTelegramHandler> logger)
        {
            _logger = logger;
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
