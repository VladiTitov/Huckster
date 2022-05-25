namespace Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription
{
    public class CreateSiteDescriptionCommandHandler
        : IRequestHandler<CreateSiteDescriptionCommand, Guid>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public CreateSiteDescriptionCommandHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(
            CreateSiteDescriptionCommand request,
            CancellationToken cancellationToken)
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
            await _repository.AddAsync(siteDescription, cancellationToken);

            return siteDescription.Id;
        }
    }
}
