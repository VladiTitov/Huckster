using Parser.Core.Domain.Models;

namespace Parser.Infrastructure.HtmlAgilityPackService.Interfaces
{
    public interface IParserService
    {
        IEnumerable<T> GetData<T>(SiteDescription siteDescription);
    }
}
