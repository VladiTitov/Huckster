using Microsoft.Extensions.DependencyInjection;
using Parser.Core.Application.Features.Parser;
using Parser.Core.Application.Features.Parser.Interfaces;

namespace Parser.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
            .AddSingleton<IParserBackgroundServiceManager, ParserBackgroundServiceManager>();
    }
}
