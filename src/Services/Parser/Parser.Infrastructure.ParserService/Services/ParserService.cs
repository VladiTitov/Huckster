namespace Parser.Infrastructure.HtmlAgilityPackService.Services
{
    public class ParserService : IParserService
    {
        public IEnumerable<T> GetData<T>(SiteDescription siteDescription)
        {
            var htmlNodes = GetHtmlNodes(siteDescription);

            if (htmlNodes is null) return Enumerable.Empty<T>();

            return htmlNodes
                .Select(htmlNode
                    => (T)Activator
                        .CreateInstance(
                            type: siteDescription.SiteModelType,
                            args: htmlNode));
        }

        private IEnumerable<HtmlNode> GetHtmlNodes(SiteDescription siteDescription)
            => new HtmlWeb()
                .Load(siteDescription.SiteUrl)
                .DocumentNode
                .SelectNodes(siteDescription.SiteSelector);
    }
}
