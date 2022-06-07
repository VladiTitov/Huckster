namespace Selector.BackgroundTasks.TelegramService.Abstractions
{
    public abstract class BaseButtonReplyMarkup<TUserResponseLabel, TKeyboardButton> 
        : IBaseButtonReplyMarkup<TUserResponseLabel, TKeyboardButton>
        where TUserResponseLabel : IUserResponseLabel
        where TKeyboardButton : IKeyboardButton
    {
        public abstract IReplyMarkup GetReplyMarkup(
            IEnumerable<TUserResponseLabel> labels,
            int columnsCount = 2);

        public IEnumerable<IEnumerable<TKeyboardButton>> GetValuesRange(
            IEnumerable<TKeyboardButton> labels, 
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