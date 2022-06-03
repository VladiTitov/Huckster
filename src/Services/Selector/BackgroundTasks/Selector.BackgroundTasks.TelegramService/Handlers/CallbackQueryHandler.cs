namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class CallbackQueryHandler : ICallbackQueryHandler
    {
        public async Task Handle(
            ITelegramBotClient botClient,
            CallbackQuery callbackQuery,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var callbackQueryText = callbackQuery?.Data;
            var callbackQueryData = callbackQueryText.Split('_');
            var query = callbackQueryData.First();
            var id = callbackQueryData.Last();
            var message = callbackQuery?.Message;

            switch (query)
            {
                case "Изменить фильтр":

                    break;
                case "Удалить фильтр":

                    await botClient.DeleteMessageAsync(
                        chatId: message.Chat.Id,
                        messageId: message.MessageId,
                        cancellationToken: cancellationToken);
                    break;
            }
        }
    }
}