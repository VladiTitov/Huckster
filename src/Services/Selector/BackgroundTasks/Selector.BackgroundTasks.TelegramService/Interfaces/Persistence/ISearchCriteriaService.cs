namespace Selector.BackgroundTasks.TelegramService.Interfaces.Persistence
{
    internal interface ISearchCriteriaService
    {
        Task UpdateModelAsync(
            SearchCriteriaModel searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteModelAsync(
            SearchCriteriaModel searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<SearchCriteriaModel> GetModelByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task AddModelAsync(
            SearchCriteriaModel model,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IReadOnlyList<SearchCriteriaModel>> GetModelListByFilterAsync(
            Expression<Func<SearchCriteriaModel, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
