namespace Selector.Core.Application.Features.Telegram.Interfaces
{
    public interface ITelegramBackgroundServiceManager
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
