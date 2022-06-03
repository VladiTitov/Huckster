namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IBaseButtonReplyMarkup
    {
        IReplyMarkup GetReplyMarkup(
            IEnumerable<string> labels,
            int columnsCount = 2);
        IEnumerable<IEnumerable<string>> GetValuesRange(
            IEnumerable<string> labels, 
            int columns);
    }
}