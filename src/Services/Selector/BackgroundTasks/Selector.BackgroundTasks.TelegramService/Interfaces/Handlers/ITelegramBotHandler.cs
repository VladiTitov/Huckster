namespace Selector.BackgroundTasks.TelegramService.Interfaces.Handlers
{
    internal interface ITelegramBotHandler
    {
        Task HandleUpdateAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken = default(CancellationToken));

        Task HandleErrorAsync(
           ITelegramBotClient botClient,
           Exception exception,
           CancellationToken cancellationToken = default(CancellationToken));
    }
}
