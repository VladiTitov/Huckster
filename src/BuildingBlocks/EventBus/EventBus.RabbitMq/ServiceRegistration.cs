using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.RabbitMq
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddEventBusBuildingBlock(this IServiceCollection services,
            IConfigurationSection connectionConfiguration,
            IConfigurationSection? publisherConfiguration = null,
            IConfigurationSection? subscriberConfiguration = null)
            => services
                .AddRabbitMqContext(connectionConfiguration)
                .AddRabbitMqPublisher(publisherConfiguration)
                .AddRabbitMqSubscriber(subscriberConfiguration);
        private static IServiceCollection AddRabbitMqContext(this IServiceCollection services, IConfigurationSection configurationSection)
            => services
                .AddConfigurationSection<RabbitMqConnectionConfiguration>(configurationSection)
                .AddSingleton<IRabbitMqContext, RabbitMqContext>();

        private static IServiceCollection AddRabbitMqPublisher(this IServiceCollection services, IConfigurationSection? configurationSection)
            => configurationSection is not null
                ? services
                    .AddConfigurationSection<RabbitMqPublisherConfiguration>(configurationSection)
                    .AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>()
                : services;

        private static IServiceCollection AddRabbitMqSubscriber(this IServiceCollection services, IConfigurationSection? configurationSection)
            => configurationSection is not null
                ? services
                    .AddConfigurationSection<RabbitMqSubscriberConfiguration>(configurationSection)
                    .AddSingleton<IRabbitMqSubscriber, RabbitMqSubscriber>()
                    .AddSingleton<IEventProcessor, BaseEventProcessor>()
                : services;
    }
}