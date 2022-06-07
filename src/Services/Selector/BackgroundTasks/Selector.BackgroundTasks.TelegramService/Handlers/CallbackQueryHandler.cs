namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class CallbackQueryHandler : ICallbackQueryHandler
    {
        private readonly IPersistenceService _persistenceService;

        public CallbackQueryHandler(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
        }

        public async Task Handle(
            ITelegramBotClient botClient,
            CallbackQuery callbackQuery,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var entityId = callbackQuery?.Data;

            await _persistenceService.DeleteSearchCriteriaAsync(
                chat: callbackQuery.Message.Chat,
                criteriaId: new Guid(entityId),
                cancellationToken: cancellationToken);

            await botClient.DeleteMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                cancellationToken: cancellationToken);
        }
    }
}