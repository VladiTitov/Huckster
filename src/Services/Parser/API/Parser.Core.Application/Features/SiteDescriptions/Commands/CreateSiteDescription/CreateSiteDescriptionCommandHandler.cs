namespace Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription
{
    public class CreateSiteDescriptionCommandHandler
        : IRequestHandler<CreateSiteDescriptionCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public CreateSiteDescriptionCommandHandler(
            IMapper mapper,
            ISiteDescriptionRepositoryAsync repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<Guid>> Handle(
            CreateSiteDescriptionCommand request,
            CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<SiteDescription>(request);
            return await _repository.AddAsync(
                entity: entity,
                cancellationToken: cancellationToken) is SiteDescription result
                ? new Response<Guid>(
                    data: entity.Id, 
                    message: ResponseMessages.EntitySuccessfullyCreated)
                : throw new InvalidOperationException(nameof(CreateSiteDescriptionCommand));
        }
    }
}
