namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class UpdateTelegramHandler : IUpdateTelegramHandler
    {
        private readonly ILogger<ErrorTelegramHandler> _logger;

        public UpdateTelegramHandler(ILogger<ErrorTelegramHandler> logger)
        {
            _logger = logger;
        }

        public async Task HandleUpdateAsync(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (update.Type != UpdateType.Message) return;
            if (update.Message!.Type != MessageType.Text) return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;
            _logger.LogInformation($"Received a '{messageText}' message in chat {chatId}.");

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken);
        }
    }
}
