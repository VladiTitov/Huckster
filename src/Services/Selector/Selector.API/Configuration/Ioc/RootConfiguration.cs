using Selector.Core.Application;
using Selector.Infrastructure.TelagramBackgroundService;

namespace Selector.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
            => services
                .AddTelegramInfrastructure()
                .AddApplicationInfrastructure()
                .RegisterSwagger();
    }
}
