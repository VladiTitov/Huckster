namespace Selector.Core.Application.Features.SearchCriteries.Queries.GetSearchCriteriaById
{
    public class GetSearchCriteriaByIdQueryHandler
        : IRequestHandler<GetSearchCriteriaByIdQuery, SearchCriteriaModel>
    {
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;
        public GetSearchCriteriaByIdQueryHandler(ISearchCriteriaRepositoryAsync searchCriteriaRepository)
        {
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public async Task<SearchCriteriaModel> Handle(
            GetSearchCriteriaByIdQuery request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _searchCriteriaRepository.GetByIdAsync(
                id: request.Id,
                cancellationToken: cancellationToken);
        }
    }
}
