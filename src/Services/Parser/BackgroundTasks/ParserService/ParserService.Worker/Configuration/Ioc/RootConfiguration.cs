using ParserService.Core.Application;
using ParserService.Infrastructure.Persistence;
using ParserService.Infrastructure.HtmlAgilityPackService;
using ParserService.Worker.Configuration.AppSetting;
using EventBus.RabbitMq;

namespace ParserService.Worker.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
                .AppSettingsSectionsRegister(configuration)
                .AddPersistenceInfrastructure(configuration)
                .AddEventBusBuildingBlock()
                .AddParserInfrastructure()
                .AddApplicationLayer();
                
    }
}
