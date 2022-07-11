using Microsoft.Extensions.DependencyInjection;
using ParserService.Core.Application.Interfaces;
using ParserService.Core.Application.Interfaces.Repositories;

namespace ParserService.Core.Application.Services
{
    public class ParserBackgroundService : IParserBackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAdHandlerService _adHandlerService;

        public ParserBackgroundService(
            IServiceProvider serviceProvider,
            IAdHandlerService adHandlerService)
        {
            _adHandlerService = adHandlerService;
            _serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
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
                    => _adHandlerService.AdHandlerAsync(siteDescription, cancellationToken));
        }

        private async Task<IEnumerable<SiteDescription>> GetSiteDescriptions()
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ISiteDescriptionRepositoryAsync>();
            return await repository.GetAllAsync();
        }
    }
}
