using Microsoft.Extensions.DependencyInjection;

namespace TelegramService.Infrastructure.TelegramBot
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddTelegramBotService(this IServiceCollection services)
            => services
                .AddSingleton<ITelegramBotServiceClient, TelegramBotServiceClient>()
                .AddSingleton<ITelegramBotServiceClientWrapper, TelegramBotServiceClientWrapper>()
                .AddSingleton<ITelegramBotService, TelegramBotService>();
    }
}
