namespace Parser.Core.Domain.Models
{
    public class SiteDescription : BaseEntity
    {
        public string SiteName { get; set; }
        public string Description { get; set; }
        public string SiteUrl { get; set; }
        public string SiteSelector { get; set; }
        public string SiteModelTypeName { get; set; }
        public string SiteModelSolutionName { get; set; }
    }
}
