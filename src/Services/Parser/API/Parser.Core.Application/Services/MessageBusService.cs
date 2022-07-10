using System.Text.Json;
using EventBus.RabbitMq.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Parser.Core.Application.Interfaces;

namespace Parser.Core.Application.Services
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ILogger<MessageBusService> _logger;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IRabbitMqPublisher _rabbitMqPublisher;

        public MessageBusService(
            ILogger<MessageBusService> logger,
            IHostEnvironment hostEnvironment,
            IRabbitMqPublisher rabbitMqPublisher)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        public async void SendMessageAsync(AdModel ad)
        {
            if (_hostEnvironment.IsDevelopment())
                _logger.LogInformation(ad.ToString());
            var jsonMessage = JsonSerializer.Serialize(ad);
            await _rabbitMqPublisher.SendMessage(jsonMessage);
        }
    }
}
