using Parser.Core.Application.BackgroundServices.Parser;

namespace Huckster.Bot.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly ParserBackgroundServiceManager _parserBackgroundServiceManager;


        public ManagerController(ILogger<ManagerController> logger,
            ParserBackgroundServiceManager parserWorkerService)
        {
            _logger = logger;
            _parserBackgroundServiceManager = parserWorkerService;
        }

        [HttpGet]
        [Route("Start")]
        public async Task<ActionResult> StartParserService()
        {
            _logger.LogInformation($"{ApiStatusMessages.ServiceStartedMessage} {DateTime.Now}");
            await _parserBackgroundServiceManager.StartAsync(new CancellationToken());
            return Ok(ApiStatusMessages.ServiceStartedMessage);
        }

        [HttpGet]
        [Route("Stop")]
        public async Task<ActionResult> StopParserService()
        {
            _logger.LogInformation($"{ApiStatusMessages.ServiceStoppedMessage} {DateTime.Now}");
            await _parserBackgroundServiceManager.StopAsync(new CancellationToken());
            return Ok(ApiStatusMessages.ServiceStoppedMessage);
        }
    }
}
