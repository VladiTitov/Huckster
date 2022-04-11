using Parser.Infrastructure.HtmlAgilityPackService.Models;

namespace Parser.API.Configuration.AppSettings
{
    public static class AppSettingRegistration
    {
        public static IServiceCollection AppSettingsSectionsRegister(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddSingleton(configuration.GetSection("SitesDescription")
                    .Get<IEnumerable<SiteDescription>>());
    }
}
