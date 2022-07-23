using EventBus.RabbitMq.Interfaces;
using Microsoft.Extensions.Logging;

namespace SelectorService.Core.Application.Services
{
    public class SearchItemService : ISearchItemService
    {
        private readonly ILogger<SearchItemService> _logger;
        private readonly IRabbitMqSubscriber _rabbitMqSubscriber;

        public SearchItemService(
            ILogger<SearchItemService> logger, 
            IRabbitMqSubscriber rabbitMqSubscriber)
        {
            _logger = logger;
            _rabbitMqSubscriber = rabbitMqSubscriber;
        }

        public Task StartReceiving(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Service started");
            _rabbitMqSubscriber.StartService();
            return Task.CompletedTask;
        }
    }
}
