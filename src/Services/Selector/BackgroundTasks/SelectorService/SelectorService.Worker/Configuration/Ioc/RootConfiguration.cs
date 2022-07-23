using SelectorService.Core.Application;
using SelectorService.Infrastructure.Persistence;
using SelectorService.Worker.Configuration.AppSettings;

namespace SelectorService.Worker.Configuration.Ioc
{
    internal static class RootConfiguration
    {
        internal static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
            .AddPersistenceInfrastructure(configuration)
            .AppSettingsSectionsRegister(configuration)
            .AddApplicationLayer();

    }
}
