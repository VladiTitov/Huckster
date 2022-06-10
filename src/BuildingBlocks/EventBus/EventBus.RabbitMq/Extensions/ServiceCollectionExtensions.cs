using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.RabbitMq.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationSection<T>(this IServiceCollection services,
            IConfigurationSection configuration) where T : class
            => services
                .Configure<T>(configuration);
    }
}