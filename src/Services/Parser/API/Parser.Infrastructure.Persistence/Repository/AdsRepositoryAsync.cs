namespace Parser.Infrastructure.Persistence.Repository
{
    public class AdsRepositoryAsync 
        : GenericBaseRepositoryAsync<AdModel>, IAdsRepositoryAsync
    {
        public AdsRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
