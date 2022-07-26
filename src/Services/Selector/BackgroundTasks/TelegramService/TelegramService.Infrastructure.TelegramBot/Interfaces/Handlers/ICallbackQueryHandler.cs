namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    internal interface ICallbackQueryHandler
    {
        Task Handle(
            CallbackQuery callbackQuery,
            CancellationToken cancellationToken = default);
    }
}
