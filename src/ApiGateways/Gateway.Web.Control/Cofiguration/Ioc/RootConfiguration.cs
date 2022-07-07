namespace Gateway.Web.Control.Cofiguration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddEndpointsApiExplorer()
                .RegisterSwagger(configuration)
                .RegisterOcelot();
                

        public static IConfigurationBuilder AddConfigurations(this IConfigurationBuilder configuration)
            => configuration
                .ConfigureOcelot();
    }
}
