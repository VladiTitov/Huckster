using System.Text.Json;
using EventBus.RabbitMq.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IHostEnvironment _hostEnvironment;

        public ParserBackgroundServiceManager(
            ILogger<ParserBackgroundServiceManager> logger,
            IHostEnvironment hostEnvironment,
            IRabbitMqPublisher rabbitMqPublisher,
            IServiceProvider serviceProvider,
            IParserService parserService) 
            : base(logger)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _rabbitMqPublisher = rabbitMqPublisher;
            _serviceProvider = serviceProvider;
            _parserService = parserService;
            _siteDescriptions = GetSiteDescriptions().Result;
        }

        private async Task<IEnumerable<SiteDescription>> GetSiteDescriptions()
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ISiteDescriptionRepositoryAsync>();
            return await repository.GetAllAsync();
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
                    if (ad.IsNull() || await repository.IsContainsAsync(ad)) continue;
                    await repository.AddAsync(ad);
                    SendMessageInEventBus(ad);
                }
            }
        }

        private async void SendMessageInEventBus(AdModel ad)
        {
            if (_hostEnvironment.IsDevelopment())
                _logger.LogInformation(ad.ToString());
            var jsonMessage = JsonSerializer.Serialize(ad);
            await _rabbitMqPublisher.SendMessage(jsonMessage);
        }
    }
}
