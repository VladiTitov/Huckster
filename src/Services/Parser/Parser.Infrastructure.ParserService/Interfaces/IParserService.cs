namespace Parser.Infrastructure.HtmlAgilityPackService.Interfaces
{
    public interface IParserService
    {
        IEnumerable<T> GetData<T>(ISiteDescription siteDescription);
    }
}
