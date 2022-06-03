namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    public interface IInlineKeyboardService
    {
        IReplyMarkup GetReplyMarkup(
            IEnumerable<string> labels,
            int columnsCount = 2);
    }
}
