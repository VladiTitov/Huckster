namespace Selector.BackgroundTasks.TelegramService.Infrastructure.UserService
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

        public async Task UpdateUserStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await CheckUserRegistrationAsync(
                chat: chat,
                cancellationToken: cancellationToken);

            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<IUserRepositoryAsync>();

            var userId = chat.Id;
            var user = await repository.GetByFilterAsync(
                filter: _ => _.UserId.Equals(userId),
                cancellationToken: cancellationToken);

            user.UserMenuState = state;

            await repository.UpdateAsync(user, cancellationToken);
            _logger.LogInformation($"User {user.UserId} state updated");
        }

        public async Task DeleteSearchCriteriaAsync(
            Chat chat,
            Guid criteriaId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await CheckUserRegistrationAsync(
                chat: chat,
                cancellationToken: cancellationToken);


        }

        public async Task AddSearchCriteriaAsync(
            Chat chat,
            SearchCriteriaModel model, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await CheckUserRegistrationAsync(
                chat: chat,
                cancellationToken: cancellationToken);

            var userId = chat.Id;
            var user = await GetUserAsync(userId);

            model.UserId = user.Id;

            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();

            await repository.AddAsync(
                entity: model,
                cancellationToken: cancellationToken);
        }

        public async Task<IReadOnlyList<SearchCriteriaModel>> GetSearchCriteriaListAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await CheckUserRegistrationAsync(
                chat: chat,
                cancellationToken: cancellationToken);

            var userId = chat.Id;
            var user = await GetUserAsync(userId);

            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();

            return await repository.GetAllByFilterAsync(
                filter: i => i.UserId.Equals(user.Id),
                cancellationToken: cancellationToken);
        }

        private async Task<UserModel?> GetUserAsync(
            long userId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<IUserRepositoryAsync>();
            return await repository.GetByFilterAsync(
                filter: i => i.UserId.Equals(userId),
                cancellationToken: cancellationToken);
        }

        private async Task CheckUserRegistrationAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _provider.CreateScope();
            var repository = scope.ServiceProvider.GetService<IUserRepositoryAsync>();

            var userId = chat.Id;

            if (await repository.IsContainsAsync(
                predicate: _ => _.UserId.Equals(userId),
                cancellationToken: cancellationToken)) return;

            await repository.AddAsync(
                entity: new UserModel 
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