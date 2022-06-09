namespace Selector.BackgroundTasks.TelegramService.Context
{
    internal class TelegramBotContext : ITelegramBotContext
    {
        public ITelegramBotClient BotClient { get; }

        public TelegramBotContext(IConfiguration configuration)
        {
            string token = configuration.GetTelegramToken();
            BotClient = token.GetTelegramBotClient();
        }
    }
}
