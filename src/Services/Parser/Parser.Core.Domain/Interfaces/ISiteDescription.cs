namespace Parser.Core.Domain.Interfaces
{
    public interface ISiteDescription : IBaseEntity
    {
        string? SiteName { get; set; }
        string? Description { get; set; }
        string? SiteUrl { get; set; }
        string? SiteSelector { get; set; }
        string? SiteModelTypeName { get; set; }
        string? SiteModelSolutionName { get; set; }

        [JsonIgnore]
        public Type SiteModelType =>
            Type.GetType($"{SiteModelSolutionName}.{SiteModelTypeName}, {SiteModelSolutionName}")!;
    }
}
