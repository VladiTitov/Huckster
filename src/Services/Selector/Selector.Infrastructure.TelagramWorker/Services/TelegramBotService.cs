using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Microsoft.Extensions.Logging;
using Selector.Infrastructure.TelagramWorker.Interfaces;

namespace Selector.Infrastructure.TelagramWorker.Services
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly ILogger<TelegramBotService> _logger;
        public ITelegramBotClient TelegramBotClient { get; }

        private const string Token = "5234612082:AAHEthD2BBF0Kkd1Q72ap9cLyTsVFBLqlcA";

        public TelegramBotService(ILogger<TelegramBotService> logger)
        {
            _logger = logger;
            TelegramBotClient = new TelegramBotClient(token: Token);
        }

        public Task StartReceiving(CancellationToken cancellationToken)
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            TelegramBotClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                errorHandler: HandleErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken
                );

            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, 
            Update update, 
            CancellationToken cancellationToken)
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

        public Task HandleErrorAsync(ITelegramBotClient botClient, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogError(errorMessage);
            return Task.CompletedTask;
        }
    }
}
