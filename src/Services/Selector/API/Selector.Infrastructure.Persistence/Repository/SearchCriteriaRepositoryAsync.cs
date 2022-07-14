namespace Selector.Infrastructure.Persistence.Repository
{
    internal class SearchCriteriaRepositoryAsync 
        : GenericBaseRepositoryAsync<SearchCriteria>, ISearchCriteriaRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchCriteriaRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<SearchCriteria?> GetByIdAsync(
            Guid id, 
            CancellationToken cancellationToken = default)
            => await _dbContext.SearchCriteries
                .Include(sc => sc.User)
                .SingleAsync(i=>i.Id.Equals(id), cancellationToken);

        public override async Task UpdateAsync(
            SearchCriteria entity, 
            CancellationToken cancellationToken = default)
        {
            var entityInDb = await GetByIdAsync(entity.Id, cancellationToken) 
                ?? throw new InvalidOperationException(nameof(SearchCriteria));
            
            if (!entityInDb.MinCost.Equals(entity.MinCost)) entityInDb.MinCost = entity.MinCost;
            if (!entityInDb.MaxCost.Equals(entity.MaxCost)) entityInDb.MaxCost = entity.MaxCost;
            if (!entityInDb.Label.Equals(entity.Label)) entityInDb.Label = entity.Label;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
