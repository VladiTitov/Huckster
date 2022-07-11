using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using ParserService.Core.Application.Interfaces;
using ParserService.Core.Application.Interfaces.Repositories;

namespace ParserService.Core.Application.Services
{
    public class AdHandlerService : IAdHandlerService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRabbitMqPublisher _rabbitMqPublisher;
        private readonly IParserService<AdModel> _parserService;

        public AdHandlerService(
            IServiceProvider serviceProvider,
            IRabbitMqPublisher rabbitMqPublisher,
            IParserService<AdModel> parserService)
        {
            _parserService = parserService;
            _serviceProvider = serviceProvider;
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        public async Task AdHandlerAsync(
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
