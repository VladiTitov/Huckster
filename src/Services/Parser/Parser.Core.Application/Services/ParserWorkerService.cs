using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Parser.Core.Domain.Models;
using Parser.Infrastructure.HtmlAgilityPackService.Models;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;

namespace Parser.Core.Application.Services
{
    public class ParserWorkerService : BackgroundService
    {
        private readonly ILogger<AdHandlerService> _logger;
        private readonly IEnumerable<SiteDescription> _siteDescriptions;
        private readonly IParserService _parserService;

        public ParserWorkerService(ILogger<AdHandlerService> logger,
            IEnumerable<SiteDescription> siteDescriptions,
            IParserService parserService)
        {
            _logger = logger;
            _siteDescriptions = siteDescriptions;
            _parserService = parserService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    foreach (var siteDescription in _siteDescriptions)
                    {
                        SaveAdInDatabase(_parserService.GetData<AdModel>(siteDescription));
                    };
                    
                    //StartParsersInParallel(stoppingToken);
                    await Task.Delay(15000, stoppingToken).ConfigureAwait(false);
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

        private void SaveAdInDatabase(IEnumerable<AdModel> adModels)
        {
            foreach (var ad in adModels)
            {
                if (ad.IsNull()) continue;
                Console.WriteLine(ad);
            }
        }
    }
}
