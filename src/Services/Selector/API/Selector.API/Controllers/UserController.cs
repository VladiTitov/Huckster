using Selector.Core.Application.Features.Users.Queries.GetAllUsers;
using Selector.Core.Application.Features.Users.Queries.GetUserById;

namespace Selector.API.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllUsersQuery();
            return await Mediator.Send(query, cancellationToken) is IReadOnlyList<UserModel> data
                ? Ok(data)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery { Id = id };
            return await Mediator.Send(query, cancellationToken) is UserModel data
                ? Ok(data)
                : NotFound();
        }
    }
}
