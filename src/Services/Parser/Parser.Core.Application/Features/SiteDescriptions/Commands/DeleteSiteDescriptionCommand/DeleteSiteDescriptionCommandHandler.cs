using MediatR;
using Parser.Core.Domain.Models;
using Parser.Core.Application.Exceptions;
using Parser.Core.Application.Interfaces;

namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescriptionCommand
{
    public class DeleteSiteDescriptionCommandHandler
        : IRequestHandler<DeleteSiteDescriptionCommand>
    {
        private readonly ISiteDescriptionDbContext _dbContext;

        public DeleteSiteDescriptionCommandHandler(ISiteDescriptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteSiteDescriptionCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.SitesDescriptions
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SiteDescription), request.Id);
            }

            _dbContext.SitesDescriptions.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
