using Selector.Core.Application.Interfaces;

namespace Selector.BackgroundTasks.SelectorService.Infrastructure.Persistence
{
    internal class SearchCriteriaService : ISearchCriteriaService
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchCriteriaService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<SearchCriteria>> GetModelsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetService<ISearchCriteriaRepositoryAsync>();

            return await repository.GetAllAsync(cancellationToken);
        }
    }
}
