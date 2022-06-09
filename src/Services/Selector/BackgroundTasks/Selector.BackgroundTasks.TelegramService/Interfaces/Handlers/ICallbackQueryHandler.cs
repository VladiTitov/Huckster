namespace Selector.BackgroundTasks.TelegramService.Interfaces.Handlers
{
    internal interface ICallbackQueryHandler
    {
        Task Handle(
            ITelegramBotClient botClient,
            CallbackQuery callbackQuery,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}