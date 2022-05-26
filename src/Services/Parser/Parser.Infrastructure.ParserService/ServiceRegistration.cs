using Microsoft.Extensions.DependencyInjection;
using Parser.Infrastructure.HtmlAgilityPackService.Services;

namespace Parser.Infrastructure.HtmlAgilityPackService
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddParserInfrastructure(this IServiceCollection services)
            => services
                .AddSingleton(typeof(IParserService<>), typeof(ParserService<>));
    }
}