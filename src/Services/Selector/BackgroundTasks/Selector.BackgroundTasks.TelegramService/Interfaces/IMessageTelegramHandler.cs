namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    public interface IMessageTelegramHandler
    {
        Task Handle(
            ITelegramBotClient botClient,
            Message message,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
