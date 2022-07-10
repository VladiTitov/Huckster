namespace Parser.Infrastructure.HtmlAgilityPackService.Services
{
    public class ParserService<T> : IParserService<T> where T : BaseEntity
    {
        public IEnumerable<T> GetData(SiteDescription siteDescription)
        {
            var entityType = GetTypeInAssembly(siteDescription.SiteModelTypeName);
            if (entityType is null) throw new ArgumentNullException(nameof(entityType));

            var htmlNodes = GetHtmlNodes(siteDescription);
            if (htmlNodes is null) return Enumerable.Empty<T>();

            return GetAds(entityType, htmlNodes);
        }

        private IEnumerable<T> GetAds(Type type, IEnumerable<HtmlNode> htmlNodes) 
            => htmlNodes.Select(htmlNode => 
                    (T)Activator.CreateInstance(
                            type: type,
                            args: htmlNode));

        private Type? GetTypeInAssembly(string typeName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var types = asm.GetTypes();
            return types.Where(i => i.Name.Equals(typeName)).SingleOrDefault();
        }

        private IEnumerable<HtmlNode> GetHtmlNodes(SiteDescription siteDescription)
            => new HtmlWeb()
                .Load(siteDescription.SiteUrl)
                .DocumentNode
                .SelectNodes(siteDescription.SiteSelector);
    }
}
