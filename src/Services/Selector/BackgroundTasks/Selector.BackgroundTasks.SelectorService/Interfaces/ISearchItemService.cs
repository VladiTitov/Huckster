namespace Selector.BackgroundTasks.SelectorService.Interfaces
{
    public interface ISearchItemService
    {
        Task StartReceiving(CancellationToken cancellationToken = default(CancellationToken));
    }
}
