namespace Selector.BackgroundTasks.TelegramService.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetTelegramToken(this IConfiguration configuration)
            => configuration
                .GetValue<string>("Token");
    }
}
