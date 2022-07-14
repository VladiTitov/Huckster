using System.Text.Json;

namespace Selector.BackgroundTasks.SelectorService.Handlers
{
    internal class MessageBusEventHandler : IEventProcessor
    {
        private readonly ILogger<MessageBusEventHandler> _logger;
        private readonly ISearchCriteriaService _searchCriteriaService;
        private readonly IRabbitMqPublisher _rabbitMqPublisher;

        public MessageBusEventHandler(
            ILogger<MessageBusEventHandler> logger,
            ISearchCriteriaService searchCriteriaService,
            IRabbitMqPublisher rabbitMqPublisher)
        {
            _logger = logger;
            _searchCriteriaService = searchCriteriaService;
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        public async void ProcessEvent(string message)
        {
            var adModel = JsonSerializer.Deserialize<AdModel>(message);
            var searchCriteriaList = await _searchCriteriaService.GetModelsAsync();
            await AdHandlerAsync(adModel, searchCriteriaList);
        }

        private async Task AdHandlerAsync(
            AdModel adModel,
            IEnumerable<SearchCriteria> searchCriteriaModels,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var searchCriteria in searchCriteriaModels)
            {
                if (adModel.Equals(searchCriteria))
                {
                    var findedItem = new FindedItem
                    {
                        Id = adModel.Id,
                        UrlId = adModel.UrlId,
                        Link = adModel.Link,
                        Label = adModel.Label,
                        Cost = adModel.Cost,
                        UserId = searchCriteria.UserId
                    };
                    var message = JsonSerializer.Serialize(findedItem);

                    await _rabbitMqPublisher.SendMessage(message);
                }
            }
        }
    }
}
