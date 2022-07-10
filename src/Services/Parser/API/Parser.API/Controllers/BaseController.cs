using System.Security.Claims;

namespace Parser.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => 
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.NewGuid()
            : Guid.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)
                .Value);
    }
}
