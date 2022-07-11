namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList
{
    public class GetSiteDescriptionListQueryHandler
        : IRequestHandler<GetSiteDescriptionListQuery, IReadOnlyList<SiteDescription>>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public GetSiteDescriptionListQueryHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<SiteDescription>> Handle(
            GetSiteDescriptionListQuery request, 
            CancellationToken cancellationToken = default)
        {
            return await _repository.GetAllAsync(cancellationToken) is IReadOnlyList<SiteDescription> data
                ? data
                : throw new NotFoundException(nameof(SiteDescription), request);
        }
    }
}
