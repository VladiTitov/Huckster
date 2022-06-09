using EventBus.RabbitMq.Models;

namespace Selector.BackgroundTasks.TelegramService.Configuration.AppSettings
{
    internal static class AppSettingsRegistration
    {
        public static IServiceCollection AppSettingsSectionsRegister(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .Configure<RabbitMqConnectionConfiguration>(configuration.GetSection("RabbitMqConnectionString"))
                .AddSingleton(configuration.GetSection("Subscribers")
                    .Get<IEnumerable<RabbitMqSubscriberConfiguration>>());
    }
}