using Parser.API.Constants;
using Microsoft.AspNetCore.Mvc;
using Parser.Core.Application.Services;

namespace Huckster.Bot.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly ParserWorkerService _parserWorkerService;


        public ManagerController(ILogger<ManagerController> logger,
            ParserWorkerService parserWorkerService)
        {
            _logger = logger;
            _parserWorkerService = parserWorkerService;
        }

        [HttpGet]
        [Route("Start")]
        public async Task<ActionResult> StartParserService()
        {
            _logger.LogInformation($"{ApiStatusMessages.ServiceStartedMessage} {DateTime.Now}");
            await _parserWorkerService.StartAsync(new CancellationToken());
            return Ok(ApiStatusMessages.ServiceStartedMessage);
        }

        [HttpGet]
        [Route("Stop")]
        public async Task<ActionResult> StopParserService()
        {
            _logger.LogInformation($"{ApiStatusMessages.ServiceStoppedMessage} {DateTime.Now}");
            await _parserWorkerService.StopAsync(new CancellationToken());
            return Ok(ApiStatusMessages.ServiceStoppedMessage);
        }
    }
}
