namespace SelectorService.Infrastructure.Persistence.Repository
{
    internal class SearchCriteriaRepositoryAsync : GenericBaseRepositoryAsync<SearchCriteria>, ISearchCriteriaRepositoryAsync
    {
        public SearchCriteriaRepositoryAsync(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
