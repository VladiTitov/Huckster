using Selector.Core.Application.Features.Users.Commands.DeleteUser;
using Selector.Core.Application.Features.Users.Queries.GetAllUsers;
using Selector.Core.Application.Features.Users.Queries.GetUserById;

namespace Selector.API.Endpoints.UserEndpoint
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

            return response.Data.Count.Equals(0)
                ? Results.NoContent()
                : Results.Ok(response);
        }

        internal static async Task<IResult> GetByIdAsync(
            Guid id, 
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new GetUserByIdQuery { Id = id },
                cancellationToken: cancellationToken);

            return response.Data is not null
                ? Results.Ok(response.Data)
                : Results.NotFound();
        }

        internal static async Task<IResult> DeleteAsync(
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new DeleteUserCommand { Id = id },
                cancellationToken: cancellationToken);

            return response.Data
                ? Results.NoContent()
                : Results.NotFound();
        }
    }
}
