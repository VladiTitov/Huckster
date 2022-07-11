namespace ParserService.Core.Application.Interfaces
{
    public interface IAdHandlerService
    {
        Task AdHandlerAsync(
            SiteDescription siteDescription,
            CancellationToken cancellationToken = default);
    }
}
