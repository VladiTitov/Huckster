namespace Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria
{
    internal class CreateSearchCriteriaCommandHandler
         : IRequestHandler<CreateSearchCriteriaCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISearchCriteriaRepositoryAsync _repository;

        public CreateSearchCriteriaCommandHandler(
            IMapper mapper,
            ISearchCriteriaRepositoryAsync repository) 
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<Guid>> Handle(
            CreateSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default)
        {
            var searchCriteria = _mapper.Map<SearchCriteria>(request);
            return await _repository.AddAsync(
                entity: searchCriteria,
                cancellationToken: cancellationToken) is SearchCriteria criteriaModel
                ? new Response<Guid>(
                    data: criteriaModel.Id,
                    message: ResponseMessages.EntitySuccessfullyCreated)
                : throw new InvalidOperationException(nameof(CreateSearchCriteriaCommand));
        }
    }
}
