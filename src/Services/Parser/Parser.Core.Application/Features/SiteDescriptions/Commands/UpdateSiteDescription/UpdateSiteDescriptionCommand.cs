namespace Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription
{
    public class UpdateSiteDescriptionCommand : IRequest<SiteDescription>
    {
        public Guid Id { get; set; }
        public string? SiteName { get; set; }
        public string? Description { get; set; }
        public string SiteUrl { get; set; }
        public string SiteSelector { get; set; }
        public string SiteModelTypeName { get; set; }
        public string SiteModelSolutionName { get; set; }
    }
}
