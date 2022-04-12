using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Parser.Infrastructure.DataAccess.Interfaces;
using Parser.Infrastructure.HtmlAgilityPackService.Models;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;
using Parser.Core.Domain.Models;

namespace Parser.Core.Application.Features.Parser
{
    public class ParserBackgroundServiceManager : CustomBackgroundService
    {
        private readonly ILogger<ParserBackgroundServiceManager> _logger;
        private readonly IEnumerable<SiteDescription> _siteDescriptions;
        private readonly IServiceProvider _serviceProvider;
        private readonly IParserService _parserService;

        public ParserBackgroundServiceManager(ILogger<ParserBackgroundServiceManager> logger,
            IServiceProvider serviceProvider,
            IEnumerable<SiteDescription> siteDescriptions,
            IParserService parserService) : base(logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _siteDescriptions = siteDescriptions;
            _parserService = parserService;
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
                    Console.WriteLine(ad);
                    var jsonMessage = JsonSerializer.Serialize(ad);
                    await repository.SaveChangesAsync();
                }
            }
        }
    }
}
