namespace Repository.Base
{
    public class GenericBaseRepositoryAsync<T>
        : IGenericBaseRepositoryAsync<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;

        public GenericBaseRepositoryAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> AsQueryable()
            => _dbContext
                .Set<T>()
                .AsQueryable();

        public virtual async Task<IReadOnlyList<T>> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken))
         => await _dbContext
                .Set<T>()       
                .ToListAsync(cancellationToken);

        public virtual async Task<IReadOnlyList<T>> GetAllByFilterAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken))
            => await _dbContext
                .Set<T>()
                .AsQueryable()
                .Where(filter)
                .ToListAsync(cancellationToken);

        public virtual async Task<T?> GetByIdAsync(
            Guid id, 
            CancellationToken cancellationToken = default(CancellationToken))
            => await _dbContext
                .Set<T>()
                .AsQueryable()
                .SingleOrDefaultAsync(
                    predicate: i => i.Id.Equals(id),
                    cancellationToken: cancellationToken);

        public virtual async Task<T?> GetByFilterAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken))
            => await _dbContext
                .Set<T>()
                .FindAsync(filter, cancellationToken);

        public virtual async Task<T> AddAsync(
            T entity, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task UpdateAsync(
            T entity, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(
            T entity, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<bool> IsContainsAsync(
            Func<T, bool> predicate,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _dbContext.Set<T>().FindAsync(predicate, cancellationToken);
            if (entity != null) return true;
            return false;
        }

    }
}
