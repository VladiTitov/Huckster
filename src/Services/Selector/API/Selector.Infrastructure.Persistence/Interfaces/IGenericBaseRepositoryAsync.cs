namespace Selector.Infrastructure.Persistence.Interfaces
{
    public interface IGenericBaseRepositoryAsync<T> where T : IBaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> IsContainsAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
