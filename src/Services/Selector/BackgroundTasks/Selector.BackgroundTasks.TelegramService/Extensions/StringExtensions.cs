namespace Selector.BackgroundTasks.TelegramService.Extensions
{
    internal static class StringExtensions
    {
        internal static double ConvertToDouble(this string value)
            => double.TryParse(value, out double result)
                ? result
                : 0;

        internal static ITelegramBotClient GetTelegramBotClient(this string token)
        {
            Guard.Against.NullOrEmpty(token, nameof(token));
            var botClient = new TelegramBotClient(token);
            Guard.Against.CanConnect(botClient, nameof(token));
            return botClient;
        }
    }
}
