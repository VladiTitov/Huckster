using Microsoft.Extensions.DependencyInjection;
using Selector.Core.Application.Features.Telegram;
using Selector.Core.Application.Features.Telegram.Interfaces;

namespace Selector.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddFeaturesServices(this IServiceCollection services)
            => services
            .AddSingleton<ITelegramBackgroundServiceManager, TelegramBackgroundServiceManager>();
    }
}
