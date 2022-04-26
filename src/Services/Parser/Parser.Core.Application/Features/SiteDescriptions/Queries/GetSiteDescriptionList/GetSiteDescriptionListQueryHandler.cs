using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Parser.Core.Application.Interfaces;

namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList
{
    public class GetSiteDescriptionListQueryHandler
        : IRequestHandler<GetSiteDescriptionListQuery, SiteDescriptionListViewModel>
    {
        private readonly ISiteDescriptionDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSiteDescriptionListQueryHandler(ISiteDescriptionDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SiteDescriptionListViewModel> Handle(GetSiteDescriptionListQuery request, CancellationToken cancellationToken)
        {
            var siteDescriptionQuery = await _dbContext.SitesDescriptions
                .ProjectTo<SiteDescriptionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SiteDescriptionListViewModel { SiteDescriptions = siteDescriptionQuery };
        }
    }
}
