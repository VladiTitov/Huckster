namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQueryHandler
        : IRequestHandler<GetSiteDescriptionDetailsQuery, SiteDescription>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;
        
        public GetSiteDescriptionDetailsQueryHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<SiteDescription> Handle(
            GetSiteDescriptionDetailsQuery request,
            CancellationToken cancellationToken = default)
            => await _repository
                .GetByIdAsync(request.Id, cancellationToken) is SiteDescription entity
                ? entity
                : throw new NotFoundException(nameof(SiteDescription), request.Id);
    }
}
