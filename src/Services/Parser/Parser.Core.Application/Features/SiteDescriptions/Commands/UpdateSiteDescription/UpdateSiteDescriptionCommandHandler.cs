namespace Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription
{
    public class UpdateSiteDescriptionCommandHandler
        : IRequestHandler<UpdateSiteDescriptionCommand, SiteDescription>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public UpdateSiteDescriptionCommandHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
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
                SiteModelTypeName = request.SiteModelTypeName
            };

            await _repository.UpdateAsync(siteDescription, cancellationToken);

            return siteDescription;
        }
    }
}