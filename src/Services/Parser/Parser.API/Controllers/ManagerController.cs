using Parser.API.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Huckster.Bot.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ILogger<ManagerController> _logger;

        public ManagerController(ILogger<ManagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Start")]
        public async Task<ActionResult> StartParserService()
        {
            _logger.LogInformation($"{ApiStatusMessages.ServiceStartedMessage} {DateTime.Now}");
            return Ok(ApiStatusMessages.ServiceStartedMessage);
        }

        [HttpGet]
        [Route("Stop")]
        public async Task<ActionResult> StopParserService()
        {
            _logger.LogInformation($"{ApiStatusMessages.ServiceStoppedMessage} {DateTime.Now}");
            return Ok(ApiStatusMessages.ServiceStoppedMessage);
        }
    }
}
