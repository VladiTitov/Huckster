namespace Selector.Core.Application.Features.SearchCriteries.Queries.GetSearchCriteriaById
{
    public class GetSearchCriteriaByIdQuery : IRequest<Response<SearchCriteria>>
    {
        public Guid Id { get; set; }
    }
}
