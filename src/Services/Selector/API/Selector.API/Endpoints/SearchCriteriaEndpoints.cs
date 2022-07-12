namespace Selector.API.Endpoints
{
    internal static class SearchCriteriaEndpoints
    {
        internal static void MapSearchCriteriaEndpoints(this WebApplication app)
        {
            app.MapGet(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.GetAllAsync)
                .Produces<IReadOnlyList<SearchCriteriaModel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .WithName("GetAllEntities")
                .WithTags("EntityQueries");

            app.MapGet(
                pattern: "api/searchCriteria/{id}",
                handler: SearchCriteriaEndpointsHandlers.GetByidAsync)
                .Produces<SearchCriteriaModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetEntityById")
                .WithTags("EntityQueries");

            app.MapPut(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.UpdateAsync)
                .Produces<SearchCriteriaModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("UpdateEntity")
                .WithTags("EntityCommands");

            app.MapPost(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.CreateAsync)
                .Produces<string>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("CreateEntity")
                .WithTags("EntityCommands");

            app.MapDelete(
                pattern: "api/searchCriteria/{id}",
                handler: SearchCriteriaEndpointsHandlers.DeleteAsync)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteEntity")
                .WithTags("EntityCommands");
        }
    }
}
