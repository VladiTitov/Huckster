namespace Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria
{
    public class CreateSearchCriteriaCommand 
        : IRequest<Guid>
    {
        public string Label { get; set; }
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
    }
}
