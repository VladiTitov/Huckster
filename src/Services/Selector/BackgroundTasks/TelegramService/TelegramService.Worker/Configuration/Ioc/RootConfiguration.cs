using TelegramService.Core.Application;

namespace TelegramService.Worker.Configuration.Ioc
{
    internal static class RootConfiguration
    {
        internal static IServiceCollection ConfigureService(
            this IServiceCollection services, 
            IConfiguration configuration)
            => services
                .AddPersistenceInfrastructure(configuration)
                .AddTelegramBotService()
                .AddApplicationLayer();

    }
}
