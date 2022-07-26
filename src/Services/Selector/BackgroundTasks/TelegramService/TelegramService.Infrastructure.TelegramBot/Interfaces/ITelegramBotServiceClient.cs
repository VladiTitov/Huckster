namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    internal interface ITelegramBotServiceClient
    {
        public ITelegramBotClient BotClient { get; }
    }
}
