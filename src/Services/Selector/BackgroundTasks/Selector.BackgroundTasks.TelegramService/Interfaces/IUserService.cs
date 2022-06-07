namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    internal interface IUserService
    {
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
