using Telegram.Bot;
using Telegram.Bot.Types;

namespace Selector.Infrastructure.TelagramWorker.Interfaces
{
    public interface ITelegramBotService
    {
        ITelegramBotClient TelegramBotClient { get; }
        Task StartReceiving(CancellationToken cancellationToken);
        Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken);
    }
}
