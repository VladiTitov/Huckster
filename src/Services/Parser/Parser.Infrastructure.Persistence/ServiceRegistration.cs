using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parser.Infrastructure.Persistence.Repository;

namespace Parser.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MyWebApiConection");

            return services
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString))
                .AddScoped(typeof(IGenericBaseRepositoryAsync<>), typeof(GenericBaseRepositoryAsync<>))
                .AddScoped<ISiteDescriptionRepositoryAsync, SiteDescriptionRepositoryAsync>()
                .AddScoped<IAdsRepositoryAsync, AdsRepositoryAsync>();
        }
    }
}