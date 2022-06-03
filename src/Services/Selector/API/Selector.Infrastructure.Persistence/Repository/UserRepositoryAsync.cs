namespace Selector.Infrastructure.Persistence.Repository
{
    public class UserRepositoryAsync
        : GenericBaseRepositoryAsync<UserModel>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<bool> IsContainsAsync(
            Func<UserModel, bool> predicate,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = AsQueryable();
            return await Task.Run(() => query.Where(predicate).Any());
        }

        public override async Task<UserModel?> GetByFilterAsync(
            Expression<Func<UserModel, bool>> predicate, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = AsQueryable();
            return await query.Where(predicate).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
