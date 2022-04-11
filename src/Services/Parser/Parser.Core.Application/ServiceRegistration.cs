using Parser.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Parser.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
            .AddSingleton<ParserWorkerService>();
    }
}
