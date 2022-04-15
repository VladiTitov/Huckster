using Selector.Core.Application;
using Selector.API.Configuration.Swagger;
using Selector.Infrastructure.TelagramWorker;

namespace Selector.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
            .AddTelegramInfrastructure()
            .AddFeaturesServices()
            .RegisterSwagger();
    }
}
