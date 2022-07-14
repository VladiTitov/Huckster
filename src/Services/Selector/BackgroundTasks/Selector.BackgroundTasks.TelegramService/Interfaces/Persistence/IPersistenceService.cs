namespace Selector.BackgroundTasks.TelegramService.Interfaces.Persistence
{
    internal interface IPersistenceService
    {
        Task<Core.Domain.Models.User?> GetUserModelById(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateSearchCriteriaAsync(
            Chat chat,
            SearchCriteria searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteSearchCriteriaAsync(
            Chat chat,
            Guid criteriaId,
            CancellationToken cancellationToken = default(CancellationToken));
        Task AddSearchCriteriaAsync(
            Chat chat,
            SearchCriteria model,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IReadOnlyList<SearchCriteria>> GetSearchCriteriaListAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
