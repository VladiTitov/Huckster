using Gateway.Web.Control.Cofiguration.Ocelot;

namespace Gateway.Web.Control.Cofiguration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services
                .AddOcelotServices();

        public static IConfigurationBuilder AddConfigurations(this IConfigurationBuilder configuration)
            => configuration
                .AddOcelotConfigurations();
    }
}
