namespace Selector.Core.Application.Features.SearchCriteries.Commands.UpdateSearchCriteria
{
    public class UpdateSearchCriteriaCommand : IRequest<Response<SearchCriteria>>
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
    }
}
