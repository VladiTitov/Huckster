using System.Text.Json;
using Microsoft.Extensions.Logging;
using Parser.Core.Domain.Models;
using Parser.Core.Application.Interfaces;
using Parser.Infrastructure.HtmlAgilityPackService.Models;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;

namespace Parser.Core.Application.Services
{
    public class AdHandlerService : IAdHandlerService
    {
        private readonly ILogger<AdHandlerService> _logger;
        private readonly IEnumerable<SiteDescription> _siteDescriptions;
        private readonly IParserService _parserService;

        public AdHandlerService(ILogger<AdHandlerService> logger,
            IEnumerable<SiteDescription> siteDescriptions,
            IParserService parserService)
        {
            _logger = logger;
            _siteDescriptions = siteDescriptions;
            _parserService = parserService;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    StartParsersInParallel(cancellationToken);
                    await Task.Delay(15000, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogInformation($"{ex.Message} {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} {DateTime.Now}");
            }
        }

        private void StartParsersInParallel(CancellationToken cancellationToken)
            => Parallel
                .ForEach(
                    source: _siteDescriptions,
                    parallelOptions: new ParallelOptions
                    {
                        CancellationToken = cancellationToken
                    },
                    body: siteDescription
                    => SaveAdInDatabase(_parserService.GetData<AdModel>(siteDescription)));

        private async void SaveAdInDatabase(IEnumerable<AdModel> adModels)
        {
            foreach (var ad in adModels)
            {
                if (ad.IsNull()) continue;
                var jsonMessage = JsonSerializer.Serialize(ad);
            }
        }
    }
}
