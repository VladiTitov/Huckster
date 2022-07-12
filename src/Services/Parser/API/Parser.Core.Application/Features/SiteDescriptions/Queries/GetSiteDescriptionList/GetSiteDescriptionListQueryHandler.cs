namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList
{
    public class GetSiteDescriptionListQueryHandler
        : IRequestHandler<GetSiteDescriptionListQuery, Response<IReadOnlyList<SiteDescription>>>
    {
        private readonly ISiteDescriptionRepositoryAsync _repository;

        public GetSiteDescriptionListQueryHandler(ISiteDescriptionRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<IReadOnlyList<SiteDescription>>> Handle(
            GetSiteDescriptionListQuery request, 
            CancellationToken cancellationToken = default)
        {
            var data = await _repository.GetAllAsync(cancellationToken);
            return new Response<IReadOnlyList<SiteDescription>>(
                data: data,
                message: ResponseMessages.EntitiesSuccessfullFinded);
        }
    }
}
