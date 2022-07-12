namespace Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription
{
    public class UpdateSiteDescriptionCommandHandler
        : IRequestHandler<UpdateSiteDescriptionCommand, Response<SiteDescription>>
    {
        private readonly IMapper _mapper;
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public UpdateSiteDescriptionCommandHandler(
            IMapper mapper,
            ISiteDescriptionRepositoryAsync repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<SiteDescription>> Handle(
            UpdateSiteDescriptionCommand request,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = _mapper.Map<SiteDescription>(request);
                await _repository.UpdateAsync(entity, cancellationToken);
                return new Response<SiteDescription>(
                    data: entity,
                    message: ResponseMessages.EntitySuccessfullyUpdated);
            }
            catch
            {
                throw new InvalidOperationException(nameof(UpdateSiteDescriptionCommand));
            }
        }
    }
}