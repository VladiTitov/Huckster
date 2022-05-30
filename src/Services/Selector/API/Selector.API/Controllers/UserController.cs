using Selector.Core.Application.Features.Users.Commands.CreateUser;
using Selector.Core.Application.Features.Users.Commands.DeleteUser;
using Selector.Core.Application.Features.Users.Commands.UpdateUser;
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateUserCommand command,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken) is Guid userId
                ? Created("", userId)
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            Guid id,
            CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand 
            {
                Id = id 
            };
            return await Mediator.Send(command, cancellationToken)
                ? NoContent()
                : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateUserCommand command,
            CancellationToken cancellationToken) 
        {
            return await Mediator.Send(command, cancellationToken) is UserModel user
                ? Ok(user)
                : NotFound();
        }
    }
}
