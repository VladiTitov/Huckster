namespace TelegramService.Infrastructure.TelegramBot.Extensions
{
    internal static class GuardsExtensions
    {
        internal static void CanConnect(this IGuardClause guardClause,
            Telegram.Bot.ITelegramBotClient botClient,
            string parameterName)
        {
            if (!botClient.TestApiAsync().Result)
                throw new ArgumentException(parameterName);
        }
    }
}
