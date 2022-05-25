using EventBus.RabbitMq.Models;

namespace Parser.API.Configuration.AppSettings
{
    public static class AppSettingRegistration
    {
        public static IServiceCollection AppSettingsSectionsRegister(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .Configure<RabbitMqConnectionConfiguration>(configuration.GetSection("RabbitMqConnectionString"))
                .Configure<RabbitMqPublisherConfiguration>(configuration.GetSection("Publisher"));
    }
}
