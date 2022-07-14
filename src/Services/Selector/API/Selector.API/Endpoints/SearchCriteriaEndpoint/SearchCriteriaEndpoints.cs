namespace Selector.API.Endpoints.SearchCriteriaEndpoint
{
    internal static class SearchCriteriaEndpoints
    {
        internal static void MapSearchCriteriaEndpoints(this WebApplication app)
        {
            app.MapGet(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.GetAllAsync)
                .Produces<IReadOnlyList<SearchCriteria>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status204NoContent)
                .WithName("GetAllSearchCriterias")
                .WithTags("SearchCriteria");

            app.MapGet(
                pattern: "api/searchCriteria/{id}",
                handler: SearchCriteriaEndpointsHandlers.GetByidAsync)
                .Produces<SearchCriteria>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetSearchCriteriaById")
                .WithTags("SearchCriteria");

            app.MapPut(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.UpdateAsync)
                .Produces<SearchCriteria>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("UpdateSearchCriteria")
                .WithTags("SearchCriteria");

            app.MapPost(
                pattern: "api/searchCriteria",
                handler: SearchCriteriaEndpointsHandlers.CreateAsync)
                .Produces<string>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("CreateSearchCriteria")
                .WithTags("SearchCriteria");

            app.MapDelete(
                pattern: "api/searchCriteria/{id}",
                handler: SearchCriteriaEndpointsHandlers.DeleteAsync)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteSearchCriteria")
                .WithTags("SearchCriteria");
        }
    }
}
