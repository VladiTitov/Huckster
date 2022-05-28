using Selector.Infrastructure.Persistence.Context;
using Selector.Infrastructure.Persistence.Migrations;

namespace Selector.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void DatabaseMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
