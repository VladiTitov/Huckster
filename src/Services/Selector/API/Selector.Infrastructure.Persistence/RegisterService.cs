using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Selector.Infrastructure.Persistence
{
    public static class RegisterService
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            return services
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString))
                .AddScoped(typeof(IGenericBaseRepositoryAsync<>), typeof(GenericBaseRepositoryAsync<>))
                .AddScoped<ISearchCriteriaRepositoryAsync, SearchCriteriaRepositoryAsync>();
        }
    }
}
