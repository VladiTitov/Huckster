namespace Selector.BackgroundTasks.TelegramService.Extensions
{
    internal static class GuardsExtensions
    {
        internal static void CanConnect(this IGuardClause guardClause, 
            ITelegramBotClient botClient,
            string parameterName)
        {
            if (!botClient.TestApiAsync().Result)
                throw new ArgumentException(parameterName);
        }
    }
}
