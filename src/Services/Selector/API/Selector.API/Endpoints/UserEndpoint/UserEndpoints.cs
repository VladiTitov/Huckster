namespace Selector.API.Endpoints.UserEndpoint
{
    internal static class UserEndpoints
    {
        internal static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet(
                pattern: "api/user",
                handler: UserEndpointsHandlers.GetAllAsync)
                .Produces<IReadOnlyList<User>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .WithName("GetAllUsers")
                .WithTags("User");

            app.MapGet(
                pattern: "api/user/{id}",
                handler: UserEndpointsHandlers.GetByIdAsync)
                .Produces<User>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetUserById")
                .WithTags("User");

            app.MapDelete(
                pattern: "api/user/{id}",
                handler: UserEndpointsHandlers.DeleteAsync)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteUser")
                .WithTags("User");
        }
    }
}
