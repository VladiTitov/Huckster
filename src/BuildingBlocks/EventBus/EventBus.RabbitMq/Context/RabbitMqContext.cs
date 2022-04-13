using RabbitMQ.Client;
using EventBus.RabbitMq.Models;
using EventBus.RabbitMq.Interfaces;
using Microsoft.Extensions.Options;

namespace EventBus.RabbitMq.Context
{
    public class RabbitMqContext : IRabbitMqContext
    {
        private IConnection _connection;
        public IConnection Connection
        {
            get { return _connection ??= CreateNewRabbitConnection(); }
            set => _connection = value;
        }

        private readonly RabbitMqConnectionConfiguration _rabbitMqConfiguration;

        public RabbitMqContext(IOptions<RabbitMqConnectionConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
        }

        public IConnection CreateNewRabbitConnection()
        {
            IConnection connection;

            try
            {
                var factory = new ConnectionFactory()
                {
                    UserName = _rabbitMqConfiguration.UserName,
                    Password = _rabbitMqConfiguration.Password,
                    Port = _rabbitMqConfiguration.Port,
                    VirtualHost = _rabbitMqConfiguration.VirtualHost,
                    HostName = _rabbitMqConfiguration.Hostname
                };

                connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                throw;
            }

            return connection;
        }
    }
}
