namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQuery
        : IRequest<SiteDescription>
    {
        public Guid Id { get; set; }
    }
}
