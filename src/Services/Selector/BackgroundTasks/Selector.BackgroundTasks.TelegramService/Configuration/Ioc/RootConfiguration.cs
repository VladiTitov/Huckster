namespace Selector.BackgroundTasks.TelegramService.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddPersistenceInfrastructure(configuration)
                .AddSingleton<ITelegramBotService, TelegramBotService>()
                .AddSingleton<ITelegramBotHandler, TelegramBotHandler>()
                .AddSingleton<IMessageTelegramHandler, MessageTelegramHandler>()
                .AddSingleton<ICallbackQueryHandler, CallbackQueryHandler>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<ISearchCriteriaService, SearchCriteriaService>()
                .AddSingleton<IPersistenceService, PersistenceService>()
                .AddSingleton<IUserResponseService, UserResponseService>()
                .AddSingleton<IInlineKeyboardService, InlineKeyboardService>()
                .AddSingleton<IKeyboardService, KeyboardService>()
                .AddHostedService<Worker>();
    }
}