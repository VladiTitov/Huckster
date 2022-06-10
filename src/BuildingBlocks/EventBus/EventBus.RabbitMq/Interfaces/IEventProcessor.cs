namespace EventBus.RabbitMq.Interfaces
{
    public interface IEventProcessor
    {
        Task ProcessEvent(string message);
    }
}
