namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    internal interface IMessageTelegramHandler
    {
        Task Handle(
            Message message,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
