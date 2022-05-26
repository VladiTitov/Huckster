using System.Reflection;
using Parser.Core.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Parser.Core.Application.BackgroundServices.Parser;
using Parser.Core.Application.Interfaces;
using Parser.Core.Application.Services;

namespace Parser.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddSingleton<ParserBackgroundServiceManager>()
            .AddSingleton<IMessageBusService, MessageBusService>()
            .AddSingleton<IAdHandlerService, AdHandlerService>()
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
    }
}
