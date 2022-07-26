namespace TelegramService.Infrastructure.TelegramBot.Wrappers
{
    internal class TelegramBotServiceClientWrapper : ITelegramBotServiceClientWrapper
    {
        private readonly ITelegramBotClient _botClient;

        public TelegramBotServiceClientWrapper(ITelegramBotServiceClient botClient)
        {
            _botClient = botClient.BotClient;
        }

        public async Task ReceiveAsync(
            Func<Telegram.Bot.ITelegramBotClient, Update, CancellationToken, Task> updateHandler, 
            Func<Telegram.Bot.ITelegramBotClient, Exception, CancellationToken, Task> errorHandler, 
            ReceiverOptions? receiverOptions = null, 
            CancellationToken cancellationToken = default)
        {
            await _botClient.ReceiveAsync(
                updateHandler: updateHandler,
                errorHandler: errorHandler,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken);
        }

        public async Task<Message> SendTextMessageAsync(
            ChatId chatId, 
            string text, 
            ParseMode? parseMode = null, 
            IEnumerable<MessageEntity>? entities = null, 
            bool? disableWebPagePreview = null, 
            bool? disableNotification = null, 
            bool? protectContent = null, 
            int? replyToMessageId = null, 
            bool? allowSendingWithoutReply = null, 
            IReplyMarkup? replyMarkup = null, 
            CancellationToken cancellationToken = default)
        {
            return await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                parseMode: parseMode,
                entities: entities,
                disableWebPagePreview: disableWebPagePreview,
                disableNotification: disableNotification,
                protectContent: protectContent,
                replyToMessageId: replyToMessageId,
                allowSendingWithoutReply:allowSendingWithoutReply,
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken);
        }

        public async Task DeleteMessageAsync(
            ChatId chatId,
            int messageId, 
            CancellationToken cancellationToken = default)
        {
            await _botClient.DeleteMessageAsync(
                chatId: chatId,
                messageId: messageId,
                cancellationToken: cancellationToken);
        }
    }
}
