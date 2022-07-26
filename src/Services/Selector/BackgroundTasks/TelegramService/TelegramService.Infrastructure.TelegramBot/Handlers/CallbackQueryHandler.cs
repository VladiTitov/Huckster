namespace TelegramService.Infrastructure.TelegramBot.Handlers
{
    internal class CallbackQueryHandler : ICallbackQueryHandler
    {
        private readonly ITelegramBotServiceClientWrapper _telegramBotClientWrapper;
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepositoryAsync;

        public CallbackQueryHandler(
            ITelegramBotServiceClientWrapper telegramBotClientWrapper,
            ISearchCriteriaRepositoryAsync searchCriteriaRepositoryAsync)
        {
            _telegramBotClientWrapper = telegramBotClientWrapper;
            _searchCriteriaRepositoryAsync = searchCriteriaRepositoryAsync;
        }

        public async Task Handle(
            CallbackQuery callbackQuery, 
            CancellationToken cancellationToken = default)
        {
            var entityId = callbackQuery.Data;

            var searchCriteria = await _searchCriteriaRepositoryAsync.GetByIdAsync(
                id: new Guid(entityId),
                cancellationToken: cancellationToken) 
                ?? throw new ArgumentNullException(nameof(SearchCriteria));

            await _searchCriteriaRepositoryAsync.DeleteAsync(
                entity: searchCriteria,
                cancellationToken: cancellationToken);

            await _telegramBotClientWrapper.DeleteMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                cancellationToken: cancellationToken);
        }
    }
}
