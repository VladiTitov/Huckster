namespace Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription
{
    public class UpdateSiteDescriptionCommandHandler
        : IRequestHandler<UpdateSiteDescriptionCommand, SiteDescription>
    {
        private readonly ISiteDescriptionDbContext _dbContext;

        public UpdateSiteDescriptionCommandHandler(ISiteDescriptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SiteDescription> Handle(
            UpdateSiteDescriptionCommand request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var siteDescription = new SiteDescription
            {
                Id = request.Id,
                SiteName = request.SiteName,
                Description = request.Description,
                SiteUrl = request.SiteUrl,
                SiteSelector = request.SiteSelector,
                SiteModelSolutionName = request.SiteModelSolutionName,
                SiteModelTypeName = request.SiteModelTypeName
            };

            _dbContext.SitesDescriptions.Update(siteDescription);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return siteDescription;
        }
    }
}
