namespace EventBus.RabbitMq.Interfaces
{
    public interface IRabbitMqSubscriber
    {
        void StopService();
        void StartService();
    }
}