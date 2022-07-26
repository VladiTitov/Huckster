namespace TelegramService.Core.Application.Interfaces
{
    public interface ITelegramBotManageService
    {
        Task StartAsync(CancellationToken cancellationToken = default);
    }
}
