using EventBus.RabbitMq.Interfaces;

namespace SelectorService.Core.Application.Interfaces
{
    public interface ISearchItemService
    {
        Task StartReceiving(CancellationToken cancellationToken = default);
    }
}
