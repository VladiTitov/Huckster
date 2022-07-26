using EventBus.RabbitMq.Models;

namespace TelegramService.Worker.Configuration.AppSettings
{
    internal static class AppSettingRegistration
    {
        public static IServiceCollection AppSettingsSectionsRegister(
            this IServiceCollection services, IConfiguration configuration)
            => services
                .Configure<RabbitMqConnectionConfiguration>(configuration.GetSection("RabbitMqConnectionString"))
                .Configure<RabbitMqPublisherConfiguration>(configuration.GetSection("Publisher"))
                .AddSingleton(configuration.GetSection("Subscribers")
                    .Get<IEnumerable<RabbitMqSubscriberConfiguration>>());
    }
}
