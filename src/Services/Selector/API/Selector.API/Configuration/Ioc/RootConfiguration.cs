using Selector.Core.Application;
using Selector.Infrastructure.Persistence;

namespace Selector.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddApplicationInfrastructure()
                .AddEndpointsApiExplorer()
                .AddPersistenceInfrastructure(configuration)
                .RegisterSwagger();
        }
    }
}
