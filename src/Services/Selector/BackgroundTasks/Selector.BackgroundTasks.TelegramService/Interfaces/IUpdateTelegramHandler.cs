namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IUpdateTelegramHandler
    {
        Task HandleUpdateAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
