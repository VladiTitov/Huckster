using ParserService.Core.Application.Interfaces;

namespace ParserService.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IParserBackgroundService _parserBackgroundService;

        public Worker(ILogger<Worker> logger,
            IParserBackgroundService parserBackgroundService)
        {
            _logger = logger;
            _parserBackgroundService = parserBackgroundService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            while (!cancellationToken.IsCancellationRequested)
            {
                await _parserBackgroundService.ExecuteAsync(cancellationToken);
                await Task.Delay(15000, cancellationToken);
            }
            
        }
    }
}