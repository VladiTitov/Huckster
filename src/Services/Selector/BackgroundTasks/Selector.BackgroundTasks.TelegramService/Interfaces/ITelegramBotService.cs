namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    public interface ITelegramBotService
    {
        Task StartReceiving(
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
