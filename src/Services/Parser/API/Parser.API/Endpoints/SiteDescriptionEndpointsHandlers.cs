using Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails;

namespace Parser.API.Endpoints
{
    internal static class SiteDescriptionEndpointsHandlers
    {
        internal static async Task<IResult> GetAllAsync(
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new GetSiteDescriptionListQuery(), 
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
                request: new GetSiteDescriptionDetailsQuery { Id = id },
                cancellationToken: cancellationToken);
            return response.Data is not null
                ? Results.Ok(response)
                : Results.NoContent();
        }

        internal static async Task<IResult> UpdateAsync(
            UpdateSiteDescriptionCommand command,
            IMediator mediator, 
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: command,
                cancellationToken: cancellationToken);

            return response.Data is not null
                ? Results.Ok(response)
                : Results.NotFound();
        }

        internal static async Task<IResult> CreateAsync(
            CreateSiteDescriptionCommand command,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            return await mediator.Send(
                 request: command,
                 cancellationToken: cancellationToken) is Response<Guid> response
                 ? Results.Created($"api/siteDescription/{response.Data}", response.Data)
                 : Results.BadRequest();
        }

        internal static async Task<IResult> DeleteAsync(
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(
                request: new DeleteSiteDescriptionCommand { Id = id },
                cancellationToken: cancellationToken);

            return response.Data
                ? Results.NoContent()
                : Results.NotFound();
        }
    }
}
