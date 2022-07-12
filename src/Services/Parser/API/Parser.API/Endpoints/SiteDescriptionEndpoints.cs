namespace Parser.API.Endpoints
{
    public static class SiteDescriptionEndpoints
    {
        public static void MapSiteDescriptionEndpoints(this WebApplication app)
        {
            app.MapGet(
                pattern: "api/siteDescription",
                handler: SiteDescriptionEndpointsHandlers.GetAllAsync)
                .Produces<Response<IReadOnlyList<SiteDescription>>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .WithName("GetAllEntities")
                .WithTags("EntityQueries");

            app.MapGet(
                pattern: "api/siteDescription/{id}",
                handler: SiteDescriptionEndpointsHandlers.GetByIdAsync)
                .Produces<Response<SiteDescription>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetEntityById")
                .WithTags("EntityQueries");

            app.MapPut(
                pattern: "api/siteDescription",
                handler: SiteDescriptionEndpointsHandlers.UpdateAsync)
                .Produces<Response<SiteDescription>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("UpdateEntity")
                .WithTags("EntityCommands");

            app.MapPost(
                pattern: "api/siteDescription",
                handler: SiteDescriptionEndpointsHandlers.CreateAsync)
                .Produces<string>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("CreateEntity")
                .WithTags("EntityCommands");

            app.MapDelete(
                pattern: "api/siteDescription/{id}",
                handler: SiteDescriptionEndpointsHandlers.DeleteAsync)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteEntity")
                .WithTags("EntityCommands");
        }
    }
}
