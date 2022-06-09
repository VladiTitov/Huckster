namespace Selector.BackgroundTasks.TelegramService.Interfaces.Handlers
{
    public interface IMessageTelegramHandler
    {
        Task Handle(
            ITelegramBotClient botClient,
            Message message,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
