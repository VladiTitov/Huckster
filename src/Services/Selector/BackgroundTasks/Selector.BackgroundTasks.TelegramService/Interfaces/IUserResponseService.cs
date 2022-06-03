namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IUserResponseService
    {
        Task<IEnumerable<IUserResponseModel>> GetDefaultResponseAsync();

        Task<IEnumerable<IUserResponseModel>> GetResponseForStartStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<IUserResponseModel>> GetResponseForAddFiltetStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<IUserResponseModel>> GetResponseForListFiltersStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
