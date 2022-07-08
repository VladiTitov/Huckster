using MMLib.SwaggerForOcelot.DependencyInjection;

namespace Gateway.Web.Control.Configuration.Ocelot
{
    public static class OcelotConfiguration
    {
        public static IServiceCollection RegisterOcelot(this IServiceCollection services)
        {
            services.AddOcelot();
            return services;
        }

        public static IConfigurationBuilder ConfigureOcelot(this IConfigurationBuilder configuration, IWebHostEnvironment hostingEnvironment)
            => configuration
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddOcelotWithSwaggerSupport(o => o.Folder = "Jsons");
    }
}
