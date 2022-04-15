using Microsoft.Extensions.DependencyInjection;
using Selector.Infrastructure.TelagramWorker.Services;
using Selector.Infrastructure.TelagramWorker.Interfaces;

namespace Selector.Infrastructure.TelagramWorker
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddTelegramInfrastructure(this IServiceCollection services)
            => services
            .AddSingleton<ITelegramBotService, TelegramBotService>();
    }
}
