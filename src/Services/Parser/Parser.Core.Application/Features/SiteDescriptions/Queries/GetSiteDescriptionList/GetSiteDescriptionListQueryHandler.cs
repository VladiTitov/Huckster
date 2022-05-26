namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList
{
    public class GetSiteDescriptionListQueryHandler
        : IRequestHandler<GetSiteDescriptionListQuery, IReadOnlyList<SiteDescription>>
    {
        private readonly IMapper _mapper;
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public GetSiteDescriptionListQueryHandler(
            IMapper mapper,
            ISiteDescriptionRepositoryAsync repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IReadOnlyList<SiteDescription>> Handle(
            GetSiteDescriptionListQuery request, 
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken) is IReadOnlyList<SiteDescription> data
                ? data
                : throw new NotFoundException(nameof(SiteDescription), request);
        }
    }
}
