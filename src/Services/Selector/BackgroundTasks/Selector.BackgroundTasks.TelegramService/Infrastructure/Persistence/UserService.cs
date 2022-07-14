using Selector.Core.Application.Interfaces;

namespace Selector.BackgroundTasks.TelegramService.Infrastructure.Persistence
{
    internal class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IServiceProvider _provider;

        public UserService(
            ILogger<UserService> logger,
            IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }       

        public async Task<Core.Domain.Models.User?> GetModelByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<IUserRepositoryAsync>();
            return await repository.GetByIdAsync(
                id: id, 
                cancellationToken: cancellationToken) is Core.Domain.Models.User model
                ? model
                : throw new NullReferenceException(nameof(Core.Domain.Models.User));
        }

        public async Task<Core.Domain.Models.User?> GetModelByUserIdAsync(
            long userId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<IUserRepositoryAsync>();
            return await repository.GetByFilterAsync(
                filter: i => i.UserId.Equals(userId),
                cancellationToken: cancellationToken) is Core.Domain.Models.User model
                ? model
                : throw new NullReferenceException(nameof(Core.Domain.Models.User));
        }

        public async Task<Guid> GetIdByUserIdAsync(
            long userId,
            CancellationToken cancellationToken = default(CancellationToken))
            => await GetModelByUserIdAsync(userId, cancellationToken) is Core.Domain.Models.User model
                ? model.Id
                : throw new NullReferenceException(nameof(Core.Domain.Models.User));
        
        public async Task CheckUserRegistrationAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<IUserRepositoryAsync>();

            var userId = chat.Id;

            if (await repository.IsContainsByFilterAsync(
                filter: _ => _.UserId.Equals(userId),
                cancellationToken: cancellationToken)) return;

            await repository.AddAsync(
                entity: new Core.Domain.Models.User 
                {
                    UserId = userId,
                    Username = chat.Username,
                    FirstName = chat.FirstName,
                    LastName = chat.LastName,
                }, 
                cancellationToken: cancellationToken);
            _logger.LogInformation($"New user registered, id = {userId}");
        }
    }
}