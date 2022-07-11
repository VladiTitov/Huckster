using Microsoft.Extensions.DependencyInjection;
using ParserService.Core.Application.Interfaces;
using ParserService.Core.Application.Services;

namespace ParserService.Core.Application
{
    public static class LayerRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
            => services
                .AddSingleton<IAdHandlerService, AdHandlerService>()
                .AddSingleton<IParserBackgroundService, ParserBackgroundService>();
    }
}
