namespace Selector.Infrastructure.TelagramBackgroundService
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddTelegramInfrastructure(this IServiceCollection services)
            => services
                .AddSingleton<IErrorTelegramHandler, ErrorTelegramHandler>()
                .AddSingleton<IUpdateTelegramHandler, UpdateTelegramHandler>();
    }
}
