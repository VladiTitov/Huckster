using System.Text.Json;
using EventBus.RabbitMq.Interfaces;

namespace Selector.BackgroundTasks.TelegramService.Infrastructure.MessageBus
{
    internal class RabbitMqSubscriberHandler : IEventProcessor
    {
        private readonly IPersistenceService _persistenceService;
        private readonly ITelegramBotContext _telegramBotContext;

        public RabbitMqSubscriberHandler(
            IPersistenceService persistenceService,
            ITelegramBotContext telegramBotContext)
        {
            _telegramBotContext = telegramBotContext;
            _persistenceService = persistenceService;
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
            var message = $"{item.Label}\n{item.Cost}\n{item.Link}";

            await _telegramBotContext.BotClient.SendTextMessageAsync(
                chatId: user.UserId,
                text: message,
                cancellationToken: cancellationToken);
        }
    }
}
