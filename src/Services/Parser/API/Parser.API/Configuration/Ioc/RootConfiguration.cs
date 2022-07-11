using EventBus.RabbitMq;
using Parser.Core.Application;
using Parser.Infrastructure.Persistence;
using Parser.API.Configuration.AutoMapper;
using Parser.API.Configuration.AppSettings;

namespace Parser.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
            .AppSettingsSectionsRegister(configuration)
            .AddPersistenceInfrastructure(configuration)
            .RegisterCors()
            .RegisterSwagger()
            .RegisterAutoMapper()
            .AddEventBusBuildingBlock()
            .AddApplicationInfrastructure();
    }
}
