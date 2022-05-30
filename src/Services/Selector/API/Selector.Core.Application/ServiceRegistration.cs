using System.Reflection;

namespace Selector.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
