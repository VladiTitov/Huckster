using Selector.Core.Application.Features.Users.Commands.CreateUser;
using Selector.Core.Application.Features.Users.Commands.DeleteUser;
using Selector.Core.Application.Features.Users.Commands.UpdateUser;
using Selector.Core.Application.Features.Users.Queries.GetAllUsers;
using Selector.Core.Application.Features.Users.Queries.GetUserById;

namespace Selector.API.Endpoints.User
{
    internal static class UserEndpointsHandlers
    {
        internal static async Task<IResult> GetAllAsync(
            IMediator mediator, 
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new GetAllUsersQuery(),
                cancellationToken: cancellationToken);

            return response is IReadOnlyList<UserModel> users
                ? Results.Ok(users)
                : Results.NoContent();
        }

        internal static async Task<IResult> GetByIdAsync(
            Guid id, 
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new GetUserByIdQuery { Id = id },
                cancellationToken: cancellationToken);

            return response is UserModel user
                ? Results.Ok(user)
                : Results.NotFound();
        }

        internal static async Task<IResult> UpdateAsync(
            UpdateUserCommand command,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: command,
                cancellationToken: cancellationToken);

            return response is UserModel user
                ? Results.Ok(user)
                : Results.NotFound();
        }

        internal static async Task<IResult> CreateAsync(
             CreateUserCommand command,
             IMediator mediator,
             CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: command,
                cancellationToken: cancellationToken);

            return response is Guid id
                ? Results.Created($"api/user/{id}", id)
                : Results.BadRequest();
        }

        internal static async Task<IResult> DeleteAsync(
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new DeleteUserCommand { Id = id },
                cancellationToken: cancellationToken);

            return response
                ? Results.NoContent()
                : Results.NotFound();
        }
    }
}
