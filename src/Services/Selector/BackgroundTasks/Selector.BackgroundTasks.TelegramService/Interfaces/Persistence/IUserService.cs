namespace Selector.BackgroundTasks.TelegramService.Interfaces.Persistence
{
    internal interface IUserService
    {
        Task<UserModel?> GetModelByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<UserModel?> GetModelByUserIdAsync(
            long userId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Guid> GetIdByUserIdAsync(
            long userId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task CheckUserRegistrationAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
