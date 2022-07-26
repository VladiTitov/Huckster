namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    internal interface ITelegramBotServiceClientWrapper
    {
        Task ReceiveAsync(
            Func<ITelegramBotClient, Update, CancellationToken, Task> updateHandler,
            Func<ITelegramBotClient, Exception, CancellationToken, Task> errorHandler,
            ReceiverOptions? receiverOptions = null,
            CancellationToken cancellationToken = default);

        Task<Message> SendTextMessageAsync(
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
            CancellationToken cancellationToken = default);

        Task DeleteMessageAsync(
            ChatId chatId,
            int messageId,
            CancellationToken cancellationToken = default);
    }
}
