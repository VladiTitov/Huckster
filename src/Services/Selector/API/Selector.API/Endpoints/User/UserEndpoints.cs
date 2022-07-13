namespace Selector.API.Endpoints.User
{
    internal static class UserEndpoints
    {
        internal static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet(
                pattern: "api/user",
                handler: UserEndpointsHandlers.GetAllAsync)
                .Produces<IReadOnlyList<UserModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .WithName("GetAllUsers")
                .WithTags("UserQueries");

            app.MapGet(
                pattern: "api/user/{id}",
                handler: UserEndpointsHandlers.GetByIdAsync)
                .Produces<UserModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetUserById")
                .WithTags("UserQueries");

            app.MapPut(
                pattern: "api/user",
                handler: UserEndpointsHandlers.UpdateAsync)
                .Produces<UserModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("UpdateUser")
                .WithTags("UserCommands");

            app.MapPost(
                pattern: "api/user",
                handler: UserEndpointsHandlers.CreateAsync)
                .Produces<string>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("CreateUser")
                .WithTags("UserCommands");

            app.MapDelete(
                pattern: "api/user/{id}",
                handler: UserEndpointsHandlers.DeleteAsync)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteUser")
                .WithTags("UserCommands");
        }
    }
}
