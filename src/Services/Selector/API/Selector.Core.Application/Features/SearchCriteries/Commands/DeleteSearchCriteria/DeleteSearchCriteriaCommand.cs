namespace Selector.Core.Application.Features.SearchCriteries.Commands.DeleteSearchCriteria
{
    public class DeleteSearchCriteriaCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
