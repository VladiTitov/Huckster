namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQuery : IRequest<Response<SiteDescription>>
    {
        public Guid Id { get; set; }
    }
}
