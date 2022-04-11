using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using EventBus.RabbitMq.Models;
using EventBus.RabbitMq.Interfaces;
using EventBus.RabbitMq.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace EventBus.RabbitMq.Services
{
    public class RabbitMqSubscriber : RabbitMqBase, IRabbitMqSubscriber
    {
        private readonly IEventProcessor _eventProcessor;
        private readonly ILogger<RabbitMqSubscriber> _logger;
        private readonly IEnumerable<RabbitMqSubscriberConfiguration> _configurations;

        public RabbitMqSubscriber(ILogger<RabbitMqSubscriber> logger,
            IRabbitMqContext context,
            IEnumerable<RabbitMqSubscriberConfiguration> configurations,
            IEventProcessor eventProcessor) : base(context)
        {
            _logger = logger;
            _eventProcessor = eventProcessor;
            _configurations = configurations;
        }

        public void StopService()
        {
            _logger.LogInformation($"Subscriber service stopping at: {DateTime.Now}");
            base.Dispose();
        }

        public async void StartService()
        {
            foreach (var configuration in _configurations)
            {
                var channel = InitializeRabbitMqChannel(configuration);
                await Execute(channel, configuration.QueueName);
                _logger.LogInformation($"Listening on the message bus. Exchange: {configuration.ExchangeName}, Queue: {configuration.QueueName}");
            }
        }

        private Task Execute(IModel channel, string queueName)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (moduleHandle, e) =>
            {
                _logger.LogInformation($"Event Received. Queue: {queueName}");

                var body = e.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());

                _eventProcessor.ProcessEvent(message);
            };

            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
