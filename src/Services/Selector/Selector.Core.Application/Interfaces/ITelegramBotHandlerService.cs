namespace Selector.Core.Application.Interfaces
{
    public interface ITelegramBotHandlerService
    {
        Task StartReceiving(
            string telegramToken,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
