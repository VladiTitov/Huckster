namespace TelegramService.Core.Application.Interfaces
{
    public interface ITelegramBotService
    {
        Task ReceiveAsync(CancellationToken cancellationToken = default);
        Task SendTextMessageAsync(
            long chatId,
            string text, 
            CancellationToken cancellationToken = default);
    }
}
