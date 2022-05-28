using Selector.Core.Application;
using Selector.Infrastructure.Persistence;

namespace Selector.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddPersistenceInfrastructure(configuration)
                .AddApplicationInfrastructure()
                .AddEndpointsApiExplorer()
                .RegisterSwagger();
    }
}
