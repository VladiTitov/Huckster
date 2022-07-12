using System.Reflection;
using Parser.Core.Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Parser.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationInfrastructure(this IServiceCollection services)
            => services
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
    }
}
