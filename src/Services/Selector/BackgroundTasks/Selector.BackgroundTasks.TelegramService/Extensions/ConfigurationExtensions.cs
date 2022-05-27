namespace Selector.BackgroundTasks.TelegramService.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetTelegramToken(this IConfiguration configuration)
        {
            return configuration.GetValue<string>("Token");
        }
    }
}
