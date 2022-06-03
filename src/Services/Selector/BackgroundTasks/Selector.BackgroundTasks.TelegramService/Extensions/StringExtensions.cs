namespace Selector.BackgroundTasks.TelegramService.Extensions
{
    internal static class StringExtensions
    {
        internal static double ConvertToDouble(this string value)
            => double.TryParse(value, out double result)
                ? result
                : 0;
    }
}
