namespace Parser.Core.Application.Interfaces
{
    public interface IMessageBusService
    {
        void SendMessageAsync(AdModel ad);
    }
}
