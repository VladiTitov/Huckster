namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQueryHandler
        : IRequestHandler<GetSiteDescriptionDetailsQuery, Response<SiteDescription>>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;
        
        public GetSiteDescriptionDetailsQueryHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<SiteDescription>> Handle(
            GetSiteDescriptionDetailsQuery request,
            CancellationToken cancellationToken = default)
            => await _repository.GetByIdAsync(
                id: request.Id, 
                cancellationToken: cancellationToken) is SiteDescription entity
                ? new Response<SiteDescription>(
                    data: entity,
                    message: ResponseMessages.EntitySuccessfullFinded)
                : throw new NotFoundException(nameof(SiteDescription), request.Id);
    }
}
