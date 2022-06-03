using Selector.Infrastructure.Persistence.Context;
using Selector.Infrastructure.Persistence.Migrations;

namespace Selector.BackgroundTasks.TelegramService.Extensions
{
    public static class HostExtensions
    {
        public static void DatabaseMigrations(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
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
