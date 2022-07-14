namespace Selector.Core.Application.Features.SearchCriteries.Commands.DeleteSearchCriteria
{
    public class DeleteSearchCriteriaCommandHandler
        : IRequestHandler<DeleteSearchCriteriaCommand, Response<bool>>
    {
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;

        public DeleteSearchCriteriaCommandHandler(
            ISearchCriteriaRepositoryAsync searchCriteriaRepository)
        {
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public async Task<Response<bool>> Handle(
            DeleteSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default)
        {
            return await _searchCriteriaRepository.GetByIdAsync(request.Id) is SearchCriteria model
                ? await DeleteEntityAsync(model, cancellationToken)
                : new Response<bool>(
                    data: false,
                    message: "Not deleted");
        }

        private async Task<Response<bool>> DeleteEntityAsync(
            SearchCriteria siteDescription,
            CancellationToken cancellationToken = default)
        {
            await _searchCriteriaRepository.DeleteAsync(siteDescription, cancellationToken);
            return new Response<bool>(
                data: true,
                message: ResponseMessages.EntitySuccessfullyDeleted);
        }
    }
}
