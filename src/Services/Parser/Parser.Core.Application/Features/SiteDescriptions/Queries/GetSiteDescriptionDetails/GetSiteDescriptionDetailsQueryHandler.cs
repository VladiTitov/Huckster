namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQueryHandler
        : IRequestHandler<GetSiteDescriptionDetailsQuery, SiteDescription>
    {
        private readonly IMapper _mapper;
        private readonly ISiteDescriptionRepositoryAsync _repository;
        
        public GetSiteDescriptionDetailsQueryHandler(
            IMapper mapper,
            ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SiteDescription> Handle(
            GetSiteDescriptionDetailsQuery request,
            CancellationToken cancellationToken)
            => await _repository
                .GetByIdAsync(request.Id, cancellationToken) is SiteDescription entity
                ? entity
                : throw new NotFoundException(nameof(SiteDescription), request.Id);
    }
}
