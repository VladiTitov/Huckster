namespace Selector.BackgroundTasks.SelectorService.Infrastructure.Persistence
{
    internal interface ISearchCriteriaService
    {
        Task<IEnumerable<SearchCriteria>> GetModelsAsync(
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
