namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQueryHandler
        : IRequestHandler<GetSiteDescriptionDetailsQuery, SiteDescriptionViewModel>
    {
        private readonly ISiteDescriptionDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSiteDescriptionDetailsQueryHandler(ISiteDescriptionDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SiteDescriptionViewModel> Handle(GetSiteDescriptionDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.SitesDescriptions
                .FirstOrDefaultAsync(siteDescription =>
                siteDescription.Id.Equals(request.Id),
                cancellationToken);

            if (entity == null) 
                throw new NotFoundException(nameof(SiteDescription), request.Id);

            return _mapper.Map<SiteDescriptionViewModel>(entity);
        }
    }
}
