namespace Selector.Core.Application.Features.SearchCriteries.Queries.GetAllSearchCriteries
{
    internal class GetAllSearchCriteriesQueryHandler
        : IRequestHandler<GetAllSearchCriteriesQuery, Response<IReadOnlyList<SearchCriteria>>>
    {
        private readonly ISearchCriteriaRepositoryAsync _repository;

        public GetAllSearchCriteriesQueryHandler(
            ISearchCriteriaRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<IReadOnlyList<SearchCriteria>>> Handle(
            GetAllSearchCriteriesQuery request, 
            CancellationToken cancellationToken = default)
        {
            var data = await _repository.GetAllAsync(cancellationToken);
            return new Response<IReadOnlyList<SearchCriteria>>(
                data: data,
                message: ResponseMessages.EntitiesSuccessfullFinded);
        }
    }
}
