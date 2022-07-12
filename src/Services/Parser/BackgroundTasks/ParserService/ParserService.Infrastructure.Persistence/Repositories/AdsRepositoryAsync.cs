namespace ParserService.Infrastructure.Persistence.Repositories
{
    public class AdsRepositoryAsync
        : GenericBaseRepositoryAsync<AdModel>, IAdsRepositoryAsync
    {
        public AdsRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
