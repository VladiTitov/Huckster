using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace TelegramService.Core.Application.Handlers
{
    internal class MessageBusEventHandler : IEventProcessor
    {
        private readonly ILogger<MessageBusEventHandler> _logger;
        private readonly ITelegramBotService _telegramBotService;
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public MessageBusEventHandler(
            ILogger<MessageBusEventHandler> logger,
            ITelegramBotService telegramBotService, 
            IUserRepositoryAsync userRepositoryAsync,
            IRabbitMqSubscriber eventBusSubscriber)
        {
            _logger = logger;
            _telegramBotService = telegramBotService;
            _userRepositoryAsync = userRepositoryAsync;
            StartMessageBusSubscribe(eventBusSubscriber);
        }

        private void StartMessageBusSubscribe(IRabbitMqSubscriber eventBusSubscriber)
        {
            _logger.LogInformation("EventBus subscriber started");
            eventBusSubscriber.StartService();
        }

        public async void ProcessEvent(string message)
        {
            var adModel = JsonSerializer.Deserialize<FindedItem>(message) 
                ?? throw new InvalidCastException(nameof(FindedItem));
            await SendMessage(adModel);
        }

        private async Task SendMessage(
           FindedItem item,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            var message = $"{item.Label}-{item.Cost}-{item.Link}";

            var user = await _userRepositoryAsync.GetByIdAsync(
                id: item.UserId,
                cancellationToken: cancellationToken) ?? throw new ArgumentNullException(nameof(User));
            
            await _telegramBotService.SendTextMessageAsync(
                chatId: user.UserId,
                text: message,
                cancellationToken: cancellationToken);
        }
    }
}
