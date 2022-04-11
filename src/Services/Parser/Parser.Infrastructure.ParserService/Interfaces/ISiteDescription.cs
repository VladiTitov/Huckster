namespace Parser.Infrastructure.HtmlAgilityPackService.Interfaces
{
    public interface ISiteDescription
    {
        string SiteName { get; set; }
        string Description { get; set; }
        string SiteUrl { get; set; }
        string SiteSelector { get; set; }
        string SiteModelTypeName { get; set; }
        string SiteModelSolutionName { get; set; }
        Type SiteModelType { get; }
    }
}
