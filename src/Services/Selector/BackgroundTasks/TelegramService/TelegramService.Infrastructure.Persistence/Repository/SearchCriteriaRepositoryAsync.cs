namespace TelegramService.Infrastructure.Persistence.Repository
{
    public class SearchCriteriaRepositoryAsync : GenericBaseRepositoryAsync<SearchCriteria>, ISearchCriteriaRepositoryAsync
    {
        public SearchCriteriaRepositoryAsync(ApplicationDbContext dbContext) 
            : base(dbContext) { }
    }
}
