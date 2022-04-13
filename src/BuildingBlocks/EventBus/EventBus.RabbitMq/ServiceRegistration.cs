using EventBus.RabbitMq.Context;
using EventBus.RabbitMq.Interfaces;
using EventBus.RabbitMq.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.RabbitMq
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddEventBusBuildingBlock(this IServiceCollection services)
            => services
            .AddSingleton<IRabbitMqContext, RabbitMqContext>()
            .AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
    }
}
