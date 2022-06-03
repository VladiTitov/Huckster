using Selector.Infrastructure.Persistence;

namespace Selector.BackgroundTasks.TelegramService.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddPersistenceInfrastructure(configuration)
                .AddHandlersInfrastructure()
                .AddHostedService<Worker>();
    }
}