namespace EventBus.RabbitMq.Interfaces
{
    public interface IRabbitMqSubscriber
    {
        Task StopService();
        Task StartService();
    }
}