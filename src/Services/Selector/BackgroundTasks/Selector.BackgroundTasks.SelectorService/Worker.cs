namespace Selector.BackgroundTasks.SelectorService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISearchItemService _searchItemService;

        public Worker(ILogger<Worker> logger,
            ISearchItemService searchItemService)
        {
            _logger = logger;
            _searchItemService = searchItemService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _searchItemService.StartReceiving(cancellationToken);
        }
    }
}