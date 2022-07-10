namespace ParserService.Core.Application.Interfaces
{
    public interface IParserBackgroundService
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
