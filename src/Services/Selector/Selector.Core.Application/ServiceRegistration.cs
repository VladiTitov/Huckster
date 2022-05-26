using Microsoft.Extensions.DependencyInjection;

namespace Selector.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
                .AddSingleton<ITelegramBotHandlerService, TelegramBotHandlerService>();
    }
}
