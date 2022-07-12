using Microsoft.Extensions.DependencyInjection;

namespace ParserService.Core.Application.Services
{
    public class ParserBackgroundService : IParserBackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAdHandler _adHandlerService;

        public ParserBackgroundService(
            IServiceProvider serviceProvider,
            IAdHandler adHandlerService)
        {
            _adHandlerService = adHandlerService;
            _serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ISiteDescriptionRepositoryAsync>();
            var siteDescriptions = await repository.GetAllAsync(cancellationToken);

            Parallel
                .ForEach(
                    source: siteDescriptions,
                    parallelOptions: new ParallelOptions
                    {
                        CancellationToken = cancellationToken
                    },
                    body: async (siteDescription) => 
                        await _adHandlerService.HandleAsync(
                            siteDescription: siteDescription, 
                            cancellationToken: cancellationToken));
        }
    }
}
