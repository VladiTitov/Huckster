namespace Selector.BackgroundTasks.SelectorService.Infrastructure.Persistence
{
    internal interface ISearchCriteriaService
    {
        Task<IEnumerable<SearchCriteriaModel>> GetModelsAsync(
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
