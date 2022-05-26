namespace Selector.Infrastructure.TelagramBackgroundService.Interfaces
{
    public interface IErrorTelegramHandler
    {
        Task HandleErrorAsync(
            ITelegramBotClient botClient,
            Exception exception,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
