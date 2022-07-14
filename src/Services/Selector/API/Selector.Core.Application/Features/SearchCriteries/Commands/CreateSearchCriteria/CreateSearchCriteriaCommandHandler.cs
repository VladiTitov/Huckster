namespace Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria
{
    public class CreateSearchCriteriaCommandHandler
         : IRequestHandler<CreateSearchCriteriaCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;

        public CreateSearchCriteriaCommandHandler(
            IMapper mapper,
            ISearchCriteriaRepositoryAsync searchCriteriaRepository) 
        {
            _mapper = mapper;
            _searchCriteriaRepository = searchCriteriaRepository;
        }

        public async Task<Response<Guid>> Handle(
            CreateSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default)
        {
            var searchCriteria = _mapper.Map<SearchCriteria>(request);
            return await _searchCriteriaRepository.AddAsync(
                entity: searchCriteria,
                cancellationToken: cancellationToken) is SearchCriteria criteriaModel
                ? new Response<Guid>(
                    data: criteriaModel.Id,
                    message: ResponseMessages.EntitySuccessfullyCreated)
                : throw new InvalidOperationException(nameof(CreateSearchCriteriaCommand));
        }
    }
}
