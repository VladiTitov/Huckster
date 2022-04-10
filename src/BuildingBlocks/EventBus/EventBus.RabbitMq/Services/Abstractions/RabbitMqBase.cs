using RabbitMQ.Client;
using EventBus.RabbitMq.Interfaces;
using EventBus.RabbitMq.Models.Abstractions;

namespace EventBus.RabbitMq.Services.Abstractions
{
    public class RabbitMqBase : IDisposable
    {
        private readonly IRabbitMqContext _context;

        public RabbitMqBase(IRabbitMqContext context)
        {
            _context = context;
        }

        public IModel InitializeRabbitMqChannel(RabbitMqConfiguration configuration)
        {
            var channel = _context.Connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: configuration.ExchangeName,
                type: configuration.ExchangeType);
            channel.QueueDeclare(
                queue: configuration.QueueName,
                durable: true,
                exclusive: false,
                autoDelete: true);
            channel.QueueBind(
                queue: configuration.QueueName,
                exchange: configuration.ExchangeName,
                routingKey: configuration.RoutingKey);

            return channel;
        }

        public void Dispose()
        {
            if (!_context.Connection.IsOpen) return;
            _context.Connection.Close();
            _context.Connection = null;
        }
    }
}
