namespace TelegramService.Infrastructure.TelegramBot.Extensions
{
    internal static class StringExtensions
    {
        internal static double ConvertToDouble(this string value)
            => double.TryParse(value, out double result)
                ? result
                : 0;

        internal static Telegram.Bot.ITelegramBotClient GetTelegramBotClient(this string token)
        {
            Guard.Against.NullOrEmpty(token, nameof(token));
            var botClient = new Telegram.Bot.TelegramBotClient(token);
            Guard.Against.CanConnect(botClient, nameof(token));
            return botClient;
        }
    }
}
