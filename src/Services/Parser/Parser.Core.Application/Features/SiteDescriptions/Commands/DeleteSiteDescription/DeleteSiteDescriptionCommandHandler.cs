namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription
{
    public class DeleteSiteDescriptionCommandHandler
        : IRequestHandler<DeleteSiteDescriptionCommand>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public DeleteSiteDescriptionCommandHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSiteDescriptionCommand request,
            CancellationToken cancellationToken)
        {
            var entityForDelete = await GetItemForDeleteAsync(request.Id, cancellationToken);
            await _repository.DeleteAsync(entityForDelete, cancellationToken);
            return Unit.Value;
        }

        private async Task<SiteDescription> GetItemForDeleteAsync(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _repository
                .GetByIdAsync(id, cancellationToken) is SiteDescription entity
                ? entity
                : throw new NotFoundException(nameof(SiteDescription), id.ToString());
        }
    }
}
