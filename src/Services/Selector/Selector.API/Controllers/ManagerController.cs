using Microsoft.AspNetCore.Mvc;

namespace Selector.API.Controllers
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
        [Route("StartSelectorService")]
        public async Task<IActionResult> StartSelectorService()
        {
            _logger.LogInformation("");
            return Ok("");
        }

        [HttpGet]
        [Route("StopSelectorService")]
        public async Task<IActionResult> StopSelectorService()
        {
            _logger.LogInformation("");
            return Ok("");
        }
    }
}
