using System.Text.Json;
using EventBus.RabbitMq.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Parser.Infrastructure.DataAccess.Interfaces;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;

namespace Parser.Core.Application.BackgroundServices.Parser
{
    public class ParserBackgroundServiceManager : CustomBackgroundService
    {
        private readonly ILogger<ParserBackgroundServiceManager> _logger;
        private readonly IEnumerable<SiteDescription> _siteDescriptions;
        private readonly IRabbitMqPublisher _rabbitMqPublisher;
        private readonly IServiceProvider _serviceProvider;
        private readonly IParserService _parserService;
        private readonly string _environmentName;

        public ParserBackgroundServiceManager(
            ILogger<ParserBackgroundServiceManager> logger,
            IHostEnvironment hostEnvironment,
            IRabbitMqPublisher rabbitMqPublisher,
            IServiceProvider serviceProvider,
            IParserService parserService) 
            : base(logger)
        {
            _logger = logger;
            _environmentName = hostEnvironment.EnvironmentName;
            _rabbitMqPublisher = rabbitMqPublisher;
            _serviceProvider = serviceProvider;
            _parserService = parserService;
            _siteDescriptions = GetSiteDescriptions();
        }

        private IEnumerable<SiteDescription> GetSiteDescriptions()
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ISiteDescriptionDbContext>();
            return repository.SitesDescriptions.ToList();
        }

        protected override void Execute(CancellationToken cancellationToken)
            => Parallel
                .ForEach(
                    source: _siteDescriptions,
                    parallelOptions: new ParallelOptions
                    {
                        CancellationToken = cancellationToken
                    },
                    body: siteDescription
                    => AdHandler(_parserService
                        .GetData<AdModel>(siteDescription)));

        private async void AdHandler(IEnumerable<AdModel> adModels)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IAdsRepositoryAsync>();
                foreach (var ad in adModels)
                {
                    if (ad.IsNull()) continue;
                    if (await repository.GetAdById(ad.UrlId) != null) continue;
                    repository.CreateAd(ad);
                    await repository.SaveChangesAsync();
                    SendMessageInEventBus(ad);
                }
            }
        }

        private async void SendMessageInEventBus(AdModel ad)
        {
            if (_environmentName.Equals("Development")) 
                _logger.LogInformation(ad.ToString());
            var jsonMessage = JsonSerializer.Serialize(ad);
            await _rabbitMqPublisher.SendMessage(jsonMessage);
        }
    }
}
