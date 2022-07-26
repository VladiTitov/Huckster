namespace TelegramService.Core.Application.Interfaces
{
    public interface IUserRepositoryAsync : IGenericBaseRepositoryAsync<User>
    {
        Task<User?> GetByUserIdAsync(
            long userId,
            CancellationToken cancellationToken = default);
    }
}
