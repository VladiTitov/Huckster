namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    public interface ITelegramBotHandlerService
    {
        Task StartReceiving(
            string telegramToken,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
