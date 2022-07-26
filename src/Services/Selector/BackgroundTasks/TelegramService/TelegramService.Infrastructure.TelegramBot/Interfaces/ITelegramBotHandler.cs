namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    internal interface ITelegramBotHandler
    {
        Task HandleUpdateAsync(
            Telegram.Bot.ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken = default);

        Task HandleErrorAsync(
           Telegram.Bot.ITelegramBotClient botClient,
           Exception exception,
           CancellationToken cancellationToken = default);
    }
}
