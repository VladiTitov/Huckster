namespace Selector.BackgroundTasks.TelegramService.Abstractions
{
    public abstract class BaseButtonReplyMarkup : IBaseButtonReplyMarkup
    {
        public abstract IReplyMarkup GetReplyMarkup(
            IEnumerable<string> labels,
            int columnsCount = 2);

        public IEnumerable<IEnumerable<string>> GetValuesRange(
            IEnumerable<string> labels, 
            int columns)
        {
            int count = labels.Count() / columns + 1;
            return Enumerable
                .Range(0, count)
                .Select(i => labels
                        .Skip(i * columns)
                        .Take(columns));
        }
    }
}