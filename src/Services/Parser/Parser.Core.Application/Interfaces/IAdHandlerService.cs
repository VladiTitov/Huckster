namespace Parser.Core.Application.Interfaces
{
    public interface IAdHandlerService
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
