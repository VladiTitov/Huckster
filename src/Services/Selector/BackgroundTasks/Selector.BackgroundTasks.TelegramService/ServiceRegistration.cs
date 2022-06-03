using Selector.BackgroundTasks.TelegramService.Infrastructure.Keyboard;
using Selector.BackgroundTasks.TelegramService.Infrastructure.UserService;

namespace Selector.BackgroundTasks.TelegramService
{
    internal static class ServiceRegistration
    {
        internal static IServiceCollection AddHandlersInfrastructure(this IServiceCollection services)
            => services
                .AddSingleton<ITelegramBotService, TelegramBotService>()
                .AddSingleton<ITelegramBotHandler, TelegramBotHandler>()
                .AddSingleton<IMessageTelegramHandler, MessageTelegramHandler>()
                .AddSingleton<ICallbackQueryHandler, CallbackQueryHandler>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<IMenuStateHandler, MenuStateHandler>()
                .AddSingleton<IUserResponseService, UserResponseService>()
                .AddSingleton<IKeyboardService, KeyboardService>()
                .AddSingleton<IInlineKeyboardService, InlineKeyboardService>();
    }
}