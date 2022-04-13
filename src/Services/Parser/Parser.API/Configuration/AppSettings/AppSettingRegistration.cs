using EventBus.RabbitMq.Models;
using Parser.Infrastructure.DataAccess.Models;
using Parser.Infrastructure.HtmlAgilityPackService.Models;

namespace Parser.API.Configuration.AppSettings
{
    public static class AppSettingRegistration
    {
        public static IServiceCollection AppSettingsSectionsRegister(this IServiceCollection services,
            IConfiguration configuration)
            => services
            .Configure<ConnectionStringSettings>(configuration.GetSection("ConnectionString"))
            .Configure<RabbitMqConnectionConfiguration>(configuration.GetSection("RabbitMqConnectionString"))
            .Configure<RabbitMqPublisherConfiguration>(configuration.GetSection("Publisher"))
                .AddSingleton(configuration.GetSection("SitesDescription")
                    .Get<IEnumerable<SiteDescription>>());
    }
}
