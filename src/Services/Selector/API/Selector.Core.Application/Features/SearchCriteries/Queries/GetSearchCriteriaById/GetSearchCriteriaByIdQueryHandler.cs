namespace Selector.Core.Application.Features.SearchCriteries.Queries.GetSearchCriteriaById
{
    internal class GetSearchCriteriaByIdQueryHandler
        : IRequestHandler<GetSearchCriteriaByIdQuery, Response<SearchCriteria>>
    {
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;
        public GetSearchCriteriaByIdQueryHandler(
            ISearchCriteriaRepositoryAsync searchCriteriaRepository)
        {
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public async Task<Response<SearchCriteria>> Handle(
            GetSearchCriteriaByIdQuery request,
            CancellationToken cancellationToken = default)
        => await _searchCriteriaRepository.GetByIdAsync(
                id: request.Id,
                cancellationToken: cancellationToken) is SearchCriteria entity
            ? new Response<SearchCriteria>(
                data: entity,
                message: ResponseMessages.EntitySuccessfullFinded)
            : new Response<SearchCriteria>(message: ResponseMessages.EntityNotFound);
    }
}

