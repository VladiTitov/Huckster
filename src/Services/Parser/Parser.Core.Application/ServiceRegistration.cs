using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Parser.Core.Application.BackgroundServices.Parser;

namespace Parser.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
            .AddSingleton<ParserBackgroundServiceManager>()
            .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
