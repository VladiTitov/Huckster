namespace Selector.BackgroundTasks.TelegramService.Infrastructure.Keyboard
{
    public class KeyboardService : BaseButtonReplyMarkup, IKeyboardService
    {
        public override IReplyMarkup GetReplyMarkup(
            IEnumerable<string> labels, 
            int columnsCount = 2)
        {
            var buttons = new List<IEnumerable<KeyboardButton>>();
            var data = GetValuesRange(labels, columnsCount);
            buttons.AddRange(data.Select(labels => GetRowKeyboardMarkup(labels)));
            return new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true
            };
        }

        private IEnumerable<KeyboardButton> GetRowKeyboardMarkup(IEnumerable<string> labels)
            => labels.Select(_ => new KeyboardButton(_));
    }
}