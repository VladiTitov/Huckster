namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface ISearchCriteriaService
    {
        Task AddModelAsync(
            SearchCriteriaModel model,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IReadOnlyList<SearchCriteriaModel>> GetModelListAsync(
            Expression<Func<SearchCriteriaModel, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
