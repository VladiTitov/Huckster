namespace Gateway.Web.Control.Configuration.Ocelot
{
    public static class OcelotConfiguration
    {
        public static IServiceCollection RegisterOcelot(this IServiceCollection services)
        {
            services.AddOcelot();
            return services;
        }

        public static IConfigurationBuilder ConfigureOcelot(this IConfigurationBuilder configuration)
            => configuration
                .AddJsonFile(
                    path: "ocelot.json", 
                    optional: false, 
                    reloadOnChange: true);
    }
}
