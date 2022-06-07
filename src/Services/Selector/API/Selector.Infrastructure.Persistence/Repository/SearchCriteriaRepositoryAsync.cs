namespace Selector.Infrastructure.Persistence.Repository
{
    internal class SearchCriteriaRepositoryAsync 
        : GenericBaseRepositoryAsync<SearchCriteriaModel>, ISearchCriteriaRepositoryAsync
    {
        public SearchCriteriaRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IReadOnlyList<SearchCriteriaModel>> GetAllByFilterAsync(
            Expression<Func<SearchCriteriaModel, bool>> filter, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = AsQueryable();
            return await query.Where(filter).ToListAsync(cancellationToken);
        }
    }
}
