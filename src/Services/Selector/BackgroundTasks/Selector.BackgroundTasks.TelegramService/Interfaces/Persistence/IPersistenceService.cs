namespace Selector.BackgroundTasks.TelegramService.Interfaces.Persistence
{
    internal interface IPersistenceService
    {
        Task<UserModel?> GetUserModelById(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken));
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
