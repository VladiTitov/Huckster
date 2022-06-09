using System.Text.Json;
using EventBus.RabbitMq.Interfaces;

namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class MessageBusEventHandler : IEventProcessor
    {
        private readonly ILogger<MessageBusEventHandler> _logger;
        private readonly IRabbitMqSubscriber _eventBusSubscriber;
        private readonly IPersistenceService _persistenceService;
        private ITelegramBotClient _botClient;

        public MessageBusEventHandler(
            ILogger<MessageBusEventHandler> logger,
            IPersistenceService persistenceService)
        {
            _logger = logger;
            _persistenceService = persistenceService;
        }

        public Task StartReceiving(
            ITelegramBotClient botClient,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _botClient = botClient;
            _eventBusSubscriber.StartService();
            return Task.CompletedTask;
        }

        public async void ProcessEvent(string message)
        {
            var adModel = JsonSerializer.Deserialize<FindedItem>(message);
            await SendMessage(adModel);
        }

        private async Task SendMessage(
            FindedItem item,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var user = await _persistenceService.GetUserModelById(
                id: item.UserId,
                cancellationToken: cancellationToken);
            var message = $"{item.Label}-{item.Cost}-{item.Link}";

            await _botClient.SendTextMessageAsync(
                chatId: user.UserId,
                text: message,
                cancellationToken: cancellationToken);
        }
    }
}
