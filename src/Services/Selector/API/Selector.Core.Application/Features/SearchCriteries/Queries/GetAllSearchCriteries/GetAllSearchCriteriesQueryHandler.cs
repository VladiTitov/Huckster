namespace Selector.Core.Application.Features.SearchCriteries.Queries.GetAllSearchCriteries
{
    public class GetAllSearchCriteriesQueryHandler
        : IRequestHandler<GetAllSearchCriteriesQuery, IReadOnlyList<SearchCriteriaModel>>
    {
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;

        public GetAllSearchCriteriesQueryHandler(ISearchCriteriaRepositoryAsync searchCriteriaRepository)
        {
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public Task<IReadOnlyList<SearchCriteriaModel>> Handle(
            GetAllSearchCriteriesQuery request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _searchCriteriaRepository.GetAllAsync();
        }
    }
}
