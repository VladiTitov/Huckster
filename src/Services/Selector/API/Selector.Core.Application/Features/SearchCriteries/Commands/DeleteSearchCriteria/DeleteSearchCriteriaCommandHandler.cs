namespace Selector.Core.Application.Features.SearchCriteries.Commands.DeleteSearchCriteria
{
    internal class DeleteSearchCriteriaCommandHandler
        : IRequestHandler<DeleteSearchCriteriaCommand, Response<bool>>
    {
        private readonly ISearchCriteriaRepositoryAsync _repository;

        public DeleteSearchCriteriaCommandHandler(
            ISearchCriteriaRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(
            DeleteSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(request.Id) is SearchCriteria model
                ? await DeleteEntityAsync(model, cancellationToken)
                : new Response<bool>(
                    data: false,
                    message: "Not deleted");
        }

        private async Task<Response<bool>> DeleteEntityAsync(
            SearchCriteria siteDescription,
            CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(siteDescription, cancellationToken);
            return new Response<bool>(
                data: true,
                message: ResponseMessages.EntitySuccessfullyDeleted);
        }
    }
}
