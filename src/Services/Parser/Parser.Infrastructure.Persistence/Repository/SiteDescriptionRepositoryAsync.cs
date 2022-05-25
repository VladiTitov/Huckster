namespace Parser.Infrastructure.Persistence.Repository
{
    public class SiteDescriptionRepositoryAsync 
        : GenericBaseRepositoryAsync<SiteDescription>, ISiteDescriptionRepositoryAsync
    {
        public SiteDescriptionRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}