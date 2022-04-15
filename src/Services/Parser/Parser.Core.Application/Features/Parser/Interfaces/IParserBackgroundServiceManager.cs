namespace Parser.Core.Application.Features.Parser.Interfaces
{
    public interface IParserBackgroundServiceManager
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
