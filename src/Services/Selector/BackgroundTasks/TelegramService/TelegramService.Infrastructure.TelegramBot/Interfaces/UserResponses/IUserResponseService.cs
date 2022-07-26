namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    internal interface IUserResponseService
    {
        IEnumerable<IUserResponseModel> GetDefaultResponse();
        IEnumerable<IUserResponseModel> GetResponseForStartState();
        IEnumerable<IUserResponseModel> GetResponseForAddFilterState();
        Task<IEnumerable<IUserResponseModel>> GetResponseForListFiltersStateAsync(
            Chat chat,
            CancellationToken cancellationToken = default);
    }
}
