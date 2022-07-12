namespace ParserService.Infrastructure.Persistence.Repositories
{
    public class SiteDescriptionRepositoryAsync
        : GenericBaseRepositoryAsync<SiteDescription>, ISiteDescriptionRepositoryAsync
    {
        public SiteDescriptionRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
