namespace Selector.BackgroundTasks.TelegramService.Interfaces.Persistence
{
    internal interface ISearchCriteriaService
    {
        Task UpdateModelAsync(
            SearchCriteria searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteModelAsync(
            SearchCriteria searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<SearchCriteria> GetModelByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task AddModelAsync(
            SearchCriteria model,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IReadOnlyList<SearchCriteria>> GetModelListByFilterAsync(
            Expression<Func<SearchCriteria, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
