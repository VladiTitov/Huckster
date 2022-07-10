using Microsoft.Extensions.DependencyInjection;

namespace ParserService.Infrastructure.HtmlAgilityPackService
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddParserInfrastructure(this IServiceCollection services)
            => services
                .AddSingleton(typeof(IParserService<>), typeof(ParserService<>));
    }
}
