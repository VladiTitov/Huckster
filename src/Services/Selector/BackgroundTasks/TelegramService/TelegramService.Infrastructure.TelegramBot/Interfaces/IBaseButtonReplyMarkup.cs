namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    public interface IBaseButtonReplyMarkup<TUserResponseLabel, TKeyboardButton>
        where TUserResponseLabel : IUserResponseLabel
        where TKeyboardButton : IKeyboardButton
    {
        IReplyMarkup GetReplyMarkup(
            IEnumerable<TUserResponseLabel> labels,
            int columnsCount = 2);
        IEnumerable<IEnumerable<TKeyboardButton>> GetValuesRange(
            IEnumerable<TKeyboardButton> labels,
            int columns);
    }
}
