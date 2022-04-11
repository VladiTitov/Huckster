using Parser.Core.Application;
using Parser.API.Configuration.Swagger;
using Parser.API.Configuration.AppSettings;
using Parser.Infrastructure.HtmlAgilityPackService;

namespace Parser.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
            .AppSettingsSectionsRegister(configuration)
            .AddApplicationInfrastructure()
            .AddParserInfrastructure()
            .RegisterSwagger();
    }
}
