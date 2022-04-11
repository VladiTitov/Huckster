using Microsoft.Extensions.DependencyInjection;
using Parser.Infrastructure.HtmlAgilityPackService.Services;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;

namespace Parser.Infrastructure.HtmlAgilityPackService
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddParserInfrastructure(this IServiceCollection services)
            => services
                .AddSingleton<IParserService, ParserService>();
    }
}
