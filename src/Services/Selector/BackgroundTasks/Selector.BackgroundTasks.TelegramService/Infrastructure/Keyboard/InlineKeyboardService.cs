namespace Selector.BackgroundTasks.TelegramService.Infrastructure.Keyboard
{
    public class InlineKeyboardService : BaseButtonReplyMarkup, IInlineKeyboardService
    {
        public override IReplyMarkup GetReplyMarkup(
            IEnumerable<string> labels,
            int columnsCount = 2)
        {
            var buttons = new List<IEnumerable<InlineKeyboardButton>>();
            var data = GetValuesRange(labels, columnsCount);
            buttons.AddRange(data.Select(labels => GetRowInlineKeyboardMarkup(
                labels: labels)));
            return new InlineKeyboardMarkup(buttons);
        }

        private IEnumerable<InlineKeyboardButton> GetRowInlineKeyboardMarkup(
            IEnumerable<string> labels)
            => labels.Select(label =>
            new InlineKeyboardButton(label)
            {
                Text = label,
                CallbackData = label
            });
    }
}
