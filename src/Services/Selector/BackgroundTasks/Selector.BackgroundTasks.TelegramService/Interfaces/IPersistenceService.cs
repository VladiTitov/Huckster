namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IPersistenceService
    {
        Task UpdateSearchCriteriaAsync(
            Chat chat,
            SearchCriteriaModel searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteSearchCriteriaAsync(
            Chat chat,
            Guid criteriaId,
            CancellationToken cancellationToken = default(CancellationToken));
        Task AddSearchCriteriaAsync(
            Chat chat,
            SearchCriteriaModel model,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IReadOnlyList<SearchCriteriaModel>> GetSearchCriteriaListAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
