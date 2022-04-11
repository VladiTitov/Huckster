using HtmlAgilityPack;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;

namespace Parser.Infrastructure.HtmlAgilityPackService.Services
{
    public class ParserService : IParserService
    {
        public IEnumerable<T> GetData<T>(ISiteDescription siteDescription)
        {
            var htmlNodes = GetHtmlNodes(siteDescription);

            if (htmlNodes == null) return Enumerable.Empty<T>();

            return htmlNodes
                .Select(htmlNode
                    => (T)Activator
                        .CreateInstance(
                            type: siteDescription.SiteModelType,
                            args: htmlNode));
        }

        private IEnumerable<HtmlNode> GetHtmlNodes(ISiteDescription siteDescription)
            => new HtmlWeb()
                .Load(siteDescription.SiteUrl)
                .DocumentNode
                .SelectNodes(siteDescription.SiteSelector);
    }
}
