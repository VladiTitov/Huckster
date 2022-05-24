namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQuery
        : IRequest<SiteDescriptionViewModel>
    {
        public Guid Id { get; set; }
    }
}
