namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription
{
    public class DeleteSiteDescriptionCommandHandler
        : IRequestHandler<DeleteSiteDescriptionCommand, bool>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public DeleteSiteDescriptionCommandHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            DeleteSiteDescriptionCommand request,
            CancellationToken cancellationToken = default)
        {
            var entityForDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entityForDelete is null) return false;
            await _repository.DeleteAsync(entityForDelete, cancellationToken);
            return true;
        }
    }
}
