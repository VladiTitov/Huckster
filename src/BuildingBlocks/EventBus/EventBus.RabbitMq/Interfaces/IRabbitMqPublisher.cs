namespace EventBus.RabbitMq.Interfaces
{
    public interface IRabbitMqPublisher
    {
        Task SendMessage(string message);
    }
}
