namespace Repository.Base
{
    public interface IGenericBaseRepositoryAsync<T> where T : BaseEntity
    {
        IQueryable<T> AsQueryable();
        Task<IReadOnlyList<T>> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IReadOnlyList<T>> GetAllByFilterAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<T?> GetByIdAsync(
            Guid id, 
            CancellationToken cancellationToken = default(CancellationToken));
        Task<T?> GetByFilterAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<T> AddAsync(
            T entity, 
            CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateAsync(
            T entity, 
            CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(
            T entity, 
            CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> IsContainsAsync(
            Func<T, bool> predicate,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}