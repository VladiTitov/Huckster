namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IErrorTelegramHandler
    {
        Task HandleErrorAsync(
            ITelegramBotClient botClient,
            Exception exception,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
