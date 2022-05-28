namespace Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria
{
    public class CreateSearchCriteriaCommandHandler
         : IRequestHandler<CreateSearchCriteriaCommand, Guid>
    {
        public readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;

        public CreateSearchCriteriaCommandHandler(
            ISearchCriteriaRepositoryAsync searchCriteriaRepository) 
        {
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public async Task<Guid> Handle(
            CreateSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = new SearchCriteriaModel
            {
                Id = new Guid(),
                Label = request.Label,
                MinCost = request.MinCost,
                MaxCost = request.MaxCost,
                UserId = request.UserId
            };

            await _searchCriteriaRepository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
