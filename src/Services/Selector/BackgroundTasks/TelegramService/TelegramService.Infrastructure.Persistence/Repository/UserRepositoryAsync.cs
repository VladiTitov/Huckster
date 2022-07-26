namespace TelegramService.Infrastructure.Persistence.Repository
{
    public class UserRepositoryAsync : GenericBaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async virtual Task<User?> GetByUserIdAsync(
            long userId,
            CancellationToken cancellationToken = default)
        => await _dbContext.Users
            .Include(sc => sc.SearchCriterias)
            .SingleOrDefaultAsync(
                predicate: i => i.UserId.Equals(userId),
                cancellationToken: cancellationToken);
    }
}
