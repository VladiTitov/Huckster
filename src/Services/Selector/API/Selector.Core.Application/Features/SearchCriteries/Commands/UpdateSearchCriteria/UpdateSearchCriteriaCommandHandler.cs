namespace Selector.Core.Application.Features.SearchCriteries.Commands.UpdateSearchCriteria
{
    public class UpdateSearchCriteriaCommandHandler
        : IRequestHandler<UpdateSearchCriteriaCommand, Response<SearchCriteria>>
    {
        private readonly IMapper _mapper;
        private readonly ISearchCriteriaRepositoryAsync _repository;

        public UpdateSearchCriteriaCommandHandler(
            IMapper mapper,
            ISearchCriteriaRepositoryAsync repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<SearchCriteria>> Handle(
            UpdateSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = _mapper.Map<SearchCriteria>(request);
                await _repository.UpdateAsync(entity, cancellationToken);
                return new Response<SearchCriteria>(
                    data: entity,
                    message: ResponseMessages.EntitySuccessfullyUpdated);
            }
            catch
            {
                throw new InvalidOperationException(nameof(UpdateSearchCriteriaCommand));
            }
        }
    }
}
