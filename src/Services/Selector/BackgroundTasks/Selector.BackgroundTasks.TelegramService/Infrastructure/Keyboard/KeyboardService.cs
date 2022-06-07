namespace Selector.BackgroundTasks.TelegramService.Infrastructure.Keyboard
{
    public class KeyboardService : 
        BaseButtonReplyMarkup<IUserResponseLabel, KeyboardButton>,
        IKeyboardService
    {
        public override IReplyMarkup GetReplyMarkup(
            IEnumerable<IUserResponseLabel> labels, 
            int columnsCount = 2)
        {
            var buttons = labels.Select(label => new KeyboardButton(label.LabelName));
            var resultButtons = GetValuesRange(buttons, columnsCount);
            return new ReplyKeyboardMarkup(resultButtons)
            {
                ResizeKeyboard = true
            };
        }
    }
}