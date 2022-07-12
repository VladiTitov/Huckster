using EventBus.RabbitMq;
using Parser.Core.Application;
using Parser.Infrastructure.Persistence;

namespace Parser.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
            .AddPersistenceInfrastructure(configuration)
            .AddEndpointsApiExplorer()
            .RegisterCors()
            .RegisterSwagger()
            .AddEventBusBuildingBlock()
            .AddApplicationInfrastructure();
    }
}
