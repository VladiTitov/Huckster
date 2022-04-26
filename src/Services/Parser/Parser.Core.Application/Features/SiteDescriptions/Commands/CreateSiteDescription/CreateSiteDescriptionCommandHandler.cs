using MediatR;
using Parser.Core.Domain.Models;
using Parser.Core.Application.Interfaces;

namespace Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription
{
    public class CreateSiteDescriptionCommandHandler
        : IRequestHandler<CreateSiteDescriptionCommand, Guid>
    {
        private readonly ISiteDescriptionDbContext _dbContext;

        public CreateSiteDescriptionCommandHandler(ISiteDescriptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateSiteDescriptionCommand request,
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

            await _dbContext.SitesDescriptions.AddAsync(siteDescription, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return siteDescription.Id;
        }
    }
}
