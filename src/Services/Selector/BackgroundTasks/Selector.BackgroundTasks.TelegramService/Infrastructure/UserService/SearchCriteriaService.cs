namespace Selector.BackgroundTasks.TelegramService.Infrastructure.UserService
{
    internal class SearchCriteriaService : ISearchCriteriaService
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchCriteriaService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task UpdateModelAsync(
            SearchCriteriaModel searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();

            var entity = await repository.GetByIdAsync(
                id: searchCriteria.Id,
                cancellationToken: cancellationToken);

            entity.Label = searchCriteria.Label;
            entity.MinCost = searchCriteria.MinCost;
            entity.MaxCost = searchCriteria.MaxCost;

            await repository.UpdateAsync(
                entity: entity,
                cancellationToken: cancellationToken);
        }

        public async Task DeleteModelAsync(
            SearchCriteriaModel searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();
            await repository.DeleteAsync(searchCriteria, cancellationToken);
        }

        public async Task<SearchCriteriaModel> GetModelByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken)) 
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();
            return await repository.GetByIdAsync(id, cancellationToken) is SearchCriteriaModel model
                ? model
                : throw new ArgumentNullException(nameof(SearchCriteriaModel));
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

        public async Task<IReadOnlyList<SearchCriteriaModel>> GetModelListByFilterAsync(
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
