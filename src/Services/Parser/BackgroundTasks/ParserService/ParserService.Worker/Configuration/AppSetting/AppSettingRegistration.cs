using EventBus.RabbitMq.Models;

namespace ParserService.Worker.Configuration.AppSetting
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
