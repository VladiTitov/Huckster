namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription
{
    public class DeleteSiteDescriptionCommandHandler
        : IRequestHandler<DeleteSiteDescriptionCommand, Response<bool>>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public DeleteSiteDescriptionCommandHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(
            DeleteSiteDescriptionCommand request,
            CancellationToken cancellationToken = default)
            => await _repository.GetByIdAsync(request.Id, cancellationToken) is SiteDescription entityForDelete
                ? await DeleteEntityAsync(entityForDelete, cancellationToken)
                : new Response<bool>(
                    data: false,
                    message: "Not deleted");

        private async Task<Response<bool>> DeleteEntityAsync(
            SiteDescription siteDescription,
            CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(siteDescription, cancellationToken);
            return new Response<bool>(
                data: true,
                message: ResponseMessages.EntitySuccessfullyDeleted);
        }
    }
}
