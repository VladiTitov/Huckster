using Microsoft.Extensions.DependencyInjection;

namespace ParserService.Core.Application
{
    public static class LayerRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
            => services
                .AddSingleton<IAdHandler, AdHandler>()
                .AddSingleton<IParserBackgroundService, ParserBackgroundService>();
    }
}
