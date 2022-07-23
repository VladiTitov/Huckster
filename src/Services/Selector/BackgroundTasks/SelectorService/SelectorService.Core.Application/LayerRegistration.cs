using EventBus.RabbitMq.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SelectorService.Core.Application.Handlers;

namespace SelectorService.Core.Application
{
    public static class LayerRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
            => services
            .AddSingleton<IEventProcessor, MessageBusEventHandler>()
            .AddSingleton<ISearchItemService, SearchItemService>();
    }
}
