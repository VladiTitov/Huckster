using Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails;

namespace Parser.API.Controllers
{
    public class SiteDescriptionController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetSiteDescriptionListQuery();
            return await Mediator.Send(query) is IReadOnlyList<SiteDescription> entities
                ? Ok(entities)
                : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetSiteDescriptionDetailsQuery
            {
                Id = id
            };
            return await Mediator.Send(query) is SiteDescription entities
                ? Ok(entities)
                : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSiteDescriptionCommand command)
        {
            return await Mediator.Send(command) is SiteDescription entity
                ? Ok(entity)
                : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSiteDescriptionCommand command)
        {
            return await Mediator.Send(command) is Guid entityId
                ? Ok(entityId)
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSiteDescriptionCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
