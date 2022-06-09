namespace Selector.BackgroundTasks.TelegramService.Context
{
    internal interface ITelegramBotContext
    {
        public ITelegramBotClient BotClient { get; }
    }
}
