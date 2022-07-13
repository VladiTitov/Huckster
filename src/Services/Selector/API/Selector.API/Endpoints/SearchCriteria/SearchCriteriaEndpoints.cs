namespace Selector.API.Endpoints.SearchCriteria
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
                .WithName("GetAllSearchCriterias")
                .WithTags("SearchCriteriaQueries");

            app.MapGet(
                pattern: "api/searchCriteria/{id}",
                handler: SearchCriteriaEndpointsHandlers.GetByidAsync)
                .Produces<SearchCriteriaModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetSearchCriteriaById")
                .WithTags("SearchCriteriaQueries");

            app.MapPut(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.UpdateAsync)
                .Produces<SearchCriteriaModel>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("UpdateSearchCriteria")
                .WithTags("SearchCriteriaCommands");

            app.MapPost(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.CreateAsync)
                .Produces<string>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("CreateSearchCriteria")
                .WithTags("SearchCriteriaCommands");

            app.MapDelete(
                pattern: "api/searchCriteria/{id}",
                handler: SearchCriteriaEndpointsHandlers.DeleteAsync)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteSearchCriteria")
                .WithTags("SearchCriteriaCommands");
        }
    }
}
