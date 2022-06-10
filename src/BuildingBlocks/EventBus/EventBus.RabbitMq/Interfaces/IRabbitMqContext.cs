namespace EventBus.RabbitMq.Interfaces
{
    public interface IRabbitMqContext
    {
        IConnection Connection { get; set; }
        IConnection CreateNewRabbitConnection();
    }
}
