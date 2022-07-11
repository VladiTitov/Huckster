using Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails;
using Common.Models;

namespace Parser.API.Controllers
{
    public class SiteDescriptionController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = new GetSiteDescriptionListQuery();
            return await Mediator.Send(query, cancellationToken) is IReadOnlyList<SiteDescription> entities
                ? Ok(entities)
                : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromBody] GetSiteDescriptionDetailsQuery query,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(query, cancellationToken) is SiteDescription entities
                ? Ok(entities)
                : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateSiteDescriptionCommand command,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken) is SiteDescription entity
                ? Ok(entity)
                : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateSiteDescriptionCommand command,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken) is Guid entityId
                ? Ok(entityId)
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteSiteDescriptionCommand command,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken)
                ? NoContent()
                : NotFound();
        }

    }
}
