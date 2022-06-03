namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IMenuStateHandler
    {
        Task<IEnumerable<IUserResponseModel>> HandleAsync(
            MenuState state,
            Message message,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}