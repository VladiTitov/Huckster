namespace Selector.Infrastructure.TelagramBackgroundService.Interfaces
{
    public interface IUpdateTelegramHandler
    {
        Task HandleUpdateAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
