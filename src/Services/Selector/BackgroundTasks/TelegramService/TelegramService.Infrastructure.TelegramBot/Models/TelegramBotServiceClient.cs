using Microsoft.Extensions.Configuration;

namespace TelegramService.Infrastructure.TelegramBot.Models
{
    internal class TelegramBotServiceClient : ITelegramBotServiceClient
    {
        public ITelegramBotClient BotClient { get; }

        private TelegramBotServiceClient(IConfiguration configuration)
        {
            string token = configuration.GetValue<string>("Token");
            BotClient = token.GetTelegramBotClient();
        }
    }
}
