using EventBus.RabbitMq;
using Parser.Core.Application;
using Parser.API.Configuration.AutoMapper;
using Parser.API.Configuration.AppSettings;
using Parser.Infrastructure.Persistence;
using Parser.Infrastructure.HtmlAgilityPackService;

namespace Parser.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
            .AppSettingsSectionsRegister(configuration)
            .AddPersistenceInfrastructure(configuration)
            .RegisterAutoMapper()
            .RegisterCors()
            .AddApplicationInfrastructure()
            .AddParserInfrastructure()
            .AddEventBusBuildingBlock()
            .RegisterSwagger();
    }
}
