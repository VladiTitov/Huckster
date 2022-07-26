using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TelegramService.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MyWebApiConection");
            return services
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString))
                .AddScoped<ISearchCriteriaRepositoryAsync, SearchCriteriaRepositoryAsync>()
                .AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
        }
    }
}
