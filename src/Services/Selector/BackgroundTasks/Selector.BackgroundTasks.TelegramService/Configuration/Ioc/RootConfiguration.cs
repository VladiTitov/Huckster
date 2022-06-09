using EventBus.RabbitMq.Context;
using EventBus.RabbitMq.Interfaces;
using EventBus.RabbitMq.Services;
using Selector.BackgroundTasks.TelegramService.Context;
using Selector.BackgroundTasks.TelegramService.Infrastructure.MessageBus;
using Selector.BackgroundTasks.TelegramService.Infrastructure.Persistence;
using Selector.BackgroundTasks.TelegramService.Interfaces.Handlers;

namespace Selector.BackgroundTasks.TelegramService.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddPersistenceInfrastructure(configuration)
                .AppSettingsSectionsRegister(configuration)
                .AddSingleton<ITelegramBotService, TelegramBotService>()
                .AddSingleton<ITelegramBotContext, TelegramBotContext>()
                .AddSingleton<ITelegramBotHandler, TelegramBotHandler>()
                .AddSingleton<IMessageTelegramHandler, MessageTelegramHandler>()
                .AddSingleton<ICallbackQueryHandler, CallbackQueryHandler>()
                .AddSingleton<IRabbitMqSubscriber, RabbitMqSubscriber>()
                .AddSingleton<IRabbitMqContext, RabbitMqContext>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<ISearchCriteriaService, SearchCriteriaService>()
                .AddSingleton<IPersistenceService, PersistenceService>()
                .AddSingleton<IEventProcessor, RabbitMqSubscriberHandler>()
                .AddSingleton<IUserResponseService, UserResponseService>()
                .AddSingleton<IInlineKeyboardService, InlineKeyboardService>()
                .AddSingleton<IKeyboardService, KeyboardService>()
                .AddHostedService<Worker>();
    }
}