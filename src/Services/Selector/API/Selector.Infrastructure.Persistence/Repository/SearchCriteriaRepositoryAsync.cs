

namespace Selector.Infrastructure.Persistence.Repository
{
    internal class SearchCriteriaRepositoryAsync 
        : GenericBaseRepositoryAsync<SearchCriteriaModel>, ISearchCriteriaRepositoryAsync
    {
        public SearchCriteriaRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
