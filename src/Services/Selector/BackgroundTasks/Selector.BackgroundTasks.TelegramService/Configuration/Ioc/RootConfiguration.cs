namespace Selector.BackgroundTasks.TelegramService.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
            => services
                .AddSingleton<ITelegramBotHandlerService, TelegramBotHandlerService>()
                .AddSingleton<IErrorTelegramHandler, ErrorTelegramHandler>()
                .AddSingleton<IUpdateTelegramHandler, UpdateTelegramHandler>()
                .AddHostedService<Worker>();
    }
}