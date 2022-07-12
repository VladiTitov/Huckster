namespace ParserService.Core.Application.Interfaces
{
    public interface IAdHandler
    {
        Task HandleAsync(
            SiteDescription siteDescription,
            CancellationToken cancellationToken = default);
    }
}
