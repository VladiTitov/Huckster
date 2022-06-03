namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    public interface IKeyboardService
    {
        IReplyMarkup GetReplyMarkup(
            IEnumerable<string> labels,
            int columnsCount = 2);
    }
}
