using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SelectorService.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString");

            return services
                .AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(connectionString))
                .AddScoped(typeof(IGenericBaseRepositoryAsync<>), typeof(GenericBaseRepositoryAsync<>))
                .AddScoped<ISearchCriteriaRepositoryAsync, SearchCriteriaRepositoryAsync>();
        }
    }
}
