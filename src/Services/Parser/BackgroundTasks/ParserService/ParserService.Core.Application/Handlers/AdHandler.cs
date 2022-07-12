using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace ParserService.Core.Application.Handlers
{
    public class AdHandler : IAdHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRabbitMqPublisher _rabbitMqPublisher;
        private readonly IParserService<AdModel> _parserService;

        public AdHandler(
            IServiceProvider serviceProvider,
            IRabbitMqPublisher rabbitMqPublisher,
            IParserService<AdModel> parserService)
        {
            _parserService = parserService;
            _serviceProvider = serviceProvider;
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        public async Task HandleAsync(
            SiteDescription siteDescription,
            CancellationToken cancellationToken = default)
        {
            var adModels = _parserService.GetData(siteDescription);

            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IAdsRepositoryAsync>();

            foreach (var ad in adModels)
            {
                if (ad.IsNull() || await repository.IsContainsByFilterAsync(i => i.UrlId.Equals(ad.UrlId), cancellationToken)) continue;
                await repository.AddAsync(ad, cancellationToken);
                var message = JsonSerializer.Serialize(ad);
                await _rabbitMqPublisher.SendMessage(message);
            }
        }
    }
}
