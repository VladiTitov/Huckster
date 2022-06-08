namespace Selector.BackgroundTasks.SelectorService.Extensions
{
    internal static class StringExtensions
    {
        internal static double ConvertToDouble(this string item)
        {
            item = Regex
                .Replace(item, "[А-Яа-я-.?!)(,:]", "");

            return double.TryParse(item, out var result) ? result : 0;
        }

        internal static bool IsContainsKey(this string item, string key)
        {
            var labelPartsArray = Regex
                .Replace(item, "[-.?!)(,:]", "")
                .ToUpper()
                .Split(' ');

            return labelPartsArray
                .Contains(key.ToUpper());
        }
    }
}
