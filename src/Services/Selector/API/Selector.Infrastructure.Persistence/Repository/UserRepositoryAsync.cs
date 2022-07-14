namespace Selector.Infrastructure.Persistence.Repository
{
    public class UserRepositoryAsync
        : GenericBaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<bool> IsContainsByFilterAsync(
            Expression<Func<User, bool>> predicate, 
            CancellationToken cancellationToken = default)
        {
            var query = AsQueryable();
            return await Task.Run(() => query.Where(predicate).Any());
        }

        public override async Task<User?> GetByFilterAsync(
            Expression<Func<User, bool>> predicate, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = AsQueryable();
            return await query.Where(predicate).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
