using Microsoft.Extensions.DependencyInjection;

namespace TelegramService.Core.Application
{
    public static class LayerRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
            => services
            .AddSingleton<IEventProcessor, MessageBusEventHandler>()
            .AddSingleton<ITelegramBotManageService, TelegramBotManageService>();
    }
}
