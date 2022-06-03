namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IUserService
    {
        Task<IReadOnlyList<SearchCriteriaModel>> GetSearchCriteriaListAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateUserStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken));
        Task AddSearchCriteriaAsync(
            Chat chat,
            SearchCriteriaModel model,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
