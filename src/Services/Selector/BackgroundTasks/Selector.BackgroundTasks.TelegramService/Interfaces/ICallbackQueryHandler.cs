namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface ICallbackQueryHandler
    {
        Task Handle(
            ITelegramBotClient botClient,
            CallbackQuery callbackQuery,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}