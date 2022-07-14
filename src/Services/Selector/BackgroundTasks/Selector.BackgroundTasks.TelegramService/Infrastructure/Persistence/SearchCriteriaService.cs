using Selector.Core.Application.Interfaces;

namespace Selector.BackgroundTasks.TelegramService.Infrastructure.Persistence
{
    internal class SearchCriteriaService : ISearchCriteriaService
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchCriteriaService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task UpdateModelAsync(
            SearchCriteria searchCriteria,
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
            SearchCriteria searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();
            await repository.DeleteAsync(searchCriteria, cancellationToken);
        }

        public async Task<SearchCriteria> GetModelByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken)) 
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();
            return await repository.GetByIdAsync(id, cancellationToken) is SearchCriteria model
                ? model
                : throw new ArgumentNullException(nameof(SearchCriteria));
        }

        public async Task AddModelAsync(
            SearchCriteria model, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();

            await repository.AddAsync(
                entity: model,
                cancellationToken: cancellationToken);
        }

        public async Task<IReadOnlyList<SearchCriteria>> GetModelListByFilterAsync(
            Expression<Func<SearchCriteria, bool>> filter,
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
