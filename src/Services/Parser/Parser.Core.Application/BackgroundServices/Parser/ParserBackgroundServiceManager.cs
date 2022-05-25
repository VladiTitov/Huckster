using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Parser.Core.Application.Interfaces;

namespace Parser.Core.Application.BackgroundServices.Parser
{
    public class ParserBackgroundServiceManager : CustomBackgroundService
    {
        private readonly ILogger<ParserBackgroundServiceManager> _logger;
        private readonly IServiceProvider _serviceProvider;
        
        private readonly IAdHandlerService _adHandlerService;

        public ParserBackgroundServiceManager(
            ILogger<ParserBackgroundServiceManager> logger,
            IServiceProvider serviceProvider,
            IAdHandlerService adHandlerService) 
            : base(logger)
        {
            _logger = logger;
            _adHandlerService = adHandlerService;
            _serviceProvider = serviceProvider;
        }

        protected override async void Execute(CancellationToken cancellationToken)
        {
            var siteDescriptions = await GetSiteDescriptions();

            Parallel
                .ForEach(
                    source: siteDescriptions,
                    parallelOptions: new ParallelOptions
                    {
                        CancellationToken = cancellationToken
                    },
                    body: siteDescription
                    => _adHandlerService.AdHandler(siteDescription));
        }

        private async Task<IEnumerable<SiteDescription>> GetSiteDescriptions()
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ISiteDescriptionRepositoryAsync>();
            return await repository.GetAllAsync();
        }
    }
}
