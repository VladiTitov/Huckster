namespace Selector.BackgroundTasks.TelegramService.Infrastructure.UserService
{
    internal class SearchCriteriaService : ISearchCriteriaService
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchCriteriaService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task AddModelAsync(
            SearchCriteriaModel model, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();

            await repository.AddAsync(
                entity: model,
                cancellationToken: cancellationToken);
        }

        public async Task<IReadOnlyList<SearchCriteriaModel>> GetModelListAsync(
            Expression<Func<SearchCriteriaModel, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();

            return await repository.GetAllByFilterAsync(
                filter: filter,
                cancellationToken: cancellationToken);
        }

    }
}
