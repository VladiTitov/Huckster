namespace Selector.Infrastructure.Persistence.Repository
{
    public class GenericBaseRepositoryAsync<T>
        : IGenericBaseRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericBaseRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(
            T entity,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(
            T entity,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => await _dbContext
                .Set<T>()
                .ToListAsync(cancellationToken);

        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = _dbContext.Set<T>().AsQueryable();

            return await data.SingleOrDefaultAsync(
                predicate: i => i.Id.Equals(id),
                cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(
            T entity,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> IsContainsAsync(
            T entity,
            CancellationToken cancellationToken = default(CancellationToken))
            => await _dbContext
                .Set<T>()
            .ContainsAsync(entity, cancellationToken);
    }
}
