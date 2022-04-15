using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomBackgroundService.Manager
{
    public abstract class BackgroundServiceManager : BackgroundService
    {
        private ILogger<BackgroundServiceManager> _logger;

        public BackgroundServiceManager(ILogger<BackgroundServiceManager> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            if (this.ExecuteTask == null) return base.StartAsync(cancellationToken);
            return Task.CompletedTask;
        }

        protected abstract void Execute(CancellationToken cancellationToken);

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Execute(cancellationToken);
                    await Task
                        .Delay(15000, cancellationToken)
                        .ConfigureAwait(false);
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
    }
}
