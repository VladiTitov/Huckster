namespace Selector.Core.Application.Features.SearchCriteries.Commands.DeleteSearchCriteria
{
    public class DeleteSearchCriteriaCommand 
        : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
