namespace Repository.Base
{
    public interface IGenericBaseRepositoryAsync<T> where T : BaseEntity
    {
        IQueryable<T> AsQueryable();
        Task<IReadOnlyList<T>> GetAllAsync(
            CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllByFilterAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(
            Guid id, 
            CancellationToken cancellationToken = default);
        Task<T?> GetByFilterAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default);
        Task<T> AddAsync(
            T entity, 
            CancellationToken cancellationToken = default);
        Task UpdateAsync(
            T entity, 
            CancellationToken cancellationToken = default);
        Task DeleteAsync(
            T entity,
            CancellationToken cancellationToken = default);
        Task<bool> IsContainsByFilterAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default);
    }
}