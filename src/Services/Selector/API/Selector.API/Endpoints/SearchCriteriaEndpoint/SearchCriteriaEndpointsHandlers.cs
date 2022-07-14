using Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria;
using Selector.Core.Application.Features.SearchCriteries.Commands.DeleteSearchCriteria;
using Selector.Core.Application.Features.SearchCriteries.Commands.UpdateSearchCriteria;
using Selector.Core.Application.Features.SearchCriteries.Queries.GetAllSearchCriteries;
using Selector.Core.Application.Features.SearchCriteries.Queries.GetSearchCriteriaById;

namespace Selector.API.Endpoints.SearchCriteriaEndpoint
{
    internal class SearchCriteriaEndpointsHandlers
    {
        internal static async Task<IResult> GetAllAsync(
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new GetAllSearchCriteriesQuery(),
                cancellationToken: cancellationToken);

            return response.Data.Count.Equals(0)
                ? Results.NoContent()
                : Results.Ok(response);
        }

        internal static async Task<IResult> GetByidAsync(
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new GetSearchCriteriaByIdQuery { Id = id },
                cancellationToken: cancellationToken);

            return response.Data is not null
                ? Results.Ok(response)
                : Results.NotFound();
        }

        internal static async Task<IResult> UpdateAsync(
            UpdateSearchCriteriaCommand command,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: command,
                cancellationToken: cancellationToken);

            return response.Data is not null
                ? Results.Ok(response.Data)
                : Results.NotFound();
        }

        internal static async Task<IResult> CreateAsync(
            CreateSearchCriteriaCommand command,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: command,
                cancellationToken: cancellationToken);

            return response.Data is Guid id
                ? Results.Created($"api/searchCriteria/{id}", id)
                : Results.BadRequest();
        }

        internal static async Task<IResult> DeleteAsync(
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new DeleteSearchCriteriaCommand { Id = id },
                cancellationToken: cancellationToken);

            return response.Data
                ? Results.NoContent()
                : Results.NotFound();
        }
    }
}
