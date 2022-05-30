namespace Selector.Core.Application.Features.SearchCriteries.Commands.DeleteSearchCriteria
{
    public class DeleteSearchCriteriaCommandHandler
        : IRequestHandler<DeleteSearchCriteriaCommand, bool>
    {
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;

        public DeleteSearchCriteriaCommandHandler(
            ISearchCriteriaRepositoryAsync searchCriteriaRepository)
        {
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public async Task<bool> Handle(
            DeleteSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var entityForDelete = await _searchCriteriaRepository.GetByIdAsync(request.Id);
            if (entityForDelete is null) return false;
            await _searchCriteriaRepository.DeleteAsync(entityForDelete);
            return true;
        }
    }
}
