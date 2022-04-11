using Microsoft.Extensions.Logging;
using Parser.Core.Domain.Models;
using Parser.Infrastructure.HtmlAgilityPackService.Models;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;

namespace Parser.Core.Application.Features.Parser
{
    public class ParserBackgroundServiceManager : CustomBackgroundService
    {
        private readonly ILogger<ParserBackgroundServiceManager> _logger;
        private readonly IEnumerable<SiteDescription> _siteDescriptions;
        private readonly IParserService _parserService;

        public ParserBackgroundServiceManager(ILogger<ParserBackgroundServiceManager> logger,
            IEnumerable<SiteDescription> siteDescriptions,
            IParserService parserService) : base(logger)
        {
            _logger = logger;
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

        private void AdHandler(IEnumerable<AdModel> adModels)
        {
            foreach (var ad in adModels)
            {
                if (ad.IsNull()) continue;
                Console.WriteLine(ad);
            }
        }

        
    }
}
