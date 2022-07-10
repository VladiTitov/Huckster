namespace ParserService.Core.Application.Interfaces
{
    public interface IParserService<T> where T : BaseEntity
    {
        IEnumerable<T> GetData(SiteDescription siteDescription);
    }
}
