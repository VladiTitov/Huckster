namespace Selector.Core.Application.Features.SearchCriteries.Commands.UpdateSearchCriteria
{
    public class UpdateSearchCriteriaCommandHandler
        : IRequestHandler<UpdateSearchCriteriaCommand, SearchCriteriaModel>
    {
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;

        public UpdateSearchCriteriaCommandHandler(
            ISearchCriteriaRepositoryAsync searchCriteriaRepository)
        {
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public async Task<SearchCriteriaModel> Handle(
            UpdateSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var updatedEntity = await _searchCriteriaRepository.GetByIdAsync(request.Id);
            if (updatedEntity is null) throw new ArgumentNullException(nameof(updatedEntity));

            updatedEntity.Label = request.Label;
            updatedEntity.MinCost = request.MinCost;
            updatedEntity.MaxCost = request.MaxCost;

            await _searchCriteriaRepository.UpdateAsync(updatedEntity, cancellationToken);

            return updatedEntity;
        }
    }
}
