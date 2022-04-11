using Microsoft.Extensions.DependencyInjection;
using Parser.Infrastructure.DataAccess.Context;
using Parser.Infrastructure.DataAccess.Interfaces;
using Parser.Infrastructure.DataAccess.Repositories;

namespace Parser.Infrastructure.DataAccess
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataAccessInfrastructure(this IServiceCollection services)
            => services
            .AddScoped<IAdsRepositoryAsync, AdsRepositoryAsync>()
            .AddScoped<ApplicationDbContext>();
    }
}
