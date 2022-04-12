using Parser.Core.Application;
using Parser.API.Configuration.Swagger;
using Parser.API.Configuration.AppSettings;
using Parser.Infrastructure.HtmlAgilityPackService;
using Parser.Infrastructure.DataAccess;

namespace Parser.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
            .AppSettingsSectionsRegister(configuration)
            .AddDataAccessInfrastructure()
            .AddApplicationInfrastructure()
            .AddParserInfrastructure()
            .RegisterSwagger();
    }
}
