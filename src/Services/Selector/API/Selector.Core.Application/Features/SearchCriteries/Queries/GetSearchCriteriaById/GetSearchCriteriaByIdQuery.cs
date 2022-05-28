namespace Selector.Core.Application.Features.SearchCriteries.Queries.GetSearchCriteriaById
{
    public class GetSearchCriteriaByIdQuery
        : IRequest<SearchCriteriaModel>
    {
        public Guid Id { get; set; }
    }
}
