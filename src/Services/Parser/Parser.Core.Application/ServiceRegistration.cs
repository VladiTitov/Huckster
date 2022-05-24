using System.Reflection;
using Parser.Core.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Parser.Core.Application.BackgroundServices.Parser;

namespace Parser.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddSingleton<ParserBackgroundServiceManager>()
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
    }
}
