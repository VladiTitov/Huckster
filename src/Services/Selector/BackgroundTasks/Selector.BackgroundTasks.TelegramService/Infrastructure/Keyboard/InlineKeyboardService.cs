namespace Selector.BackgroundTasks.TelegramService.Infrastructure.Keyboard
{
    public class InlineKeyboardService : 
        BaseButtonReplyMarkup<IUserResponseInlineLabel, InlineKeyboardButton>, 
        IInlineKeyboardService
    {
        public override IReplyMarkup GetReplyMarkup(
            IEnumerable<IUserResponseInlineLabel> labels,
            int columnsCount = 2)
        {
            var buttons = labels.Select(label =>
                new InlineKeyboardButton(label.LabelName)
                {
                    Text = label.LabelName,
                    CallbackData = label.LabelKey
                });

            var resultButtons = GetValuesRange(buttons, columnsCount);
            return new InlineKeyboardMarkup(resultButtons);
        }
    }
}