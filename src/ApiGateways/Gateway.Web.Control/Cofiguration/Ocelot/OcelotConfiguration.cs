namespace Gateway.Web.Control.Cofiguration.Ocelot
{
    public static class OcelotConfiguration
    {
        public static IServiceCollection AddOcelotServices(this IServiceCollection services)
        {
            services.AddOcelot();
            return services;
        }

        public static IConfigurationBuilder AddOcelotConfigurations(this IConfigurationBuilder configuration)
            => configuration
                .AddJsonFile(
                    path: "ocelot.json", 
                    optional: false, 
                    reloadOnChange: true);
    }
}
