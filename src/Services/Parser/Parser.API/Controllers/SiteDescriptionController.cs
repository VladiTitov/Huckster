using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parser.API.Models;
using Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescriptionCommand;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails;
using Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList;

namespace Parser.API.Controllers
{
    [Route("api/[controller]")]
    public class SiteDescriptionController : BaseController
    {
        private readonly IMapper _mapper;

        public SiteDescriptionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<SiteDescriptionListViewModel>> GetAll()
        {
            var query = new GetSiteDescriptionListQuery();
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SiteDescriptionViewModel>> GetById(Guid id)
        {
            var query = new GetSiteDescriptionDetailsQuery
            {
                Id = id
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSiteDescriptionDto createSiteDescriptionDto)
        {
            var command = _mapper.Map<CreateSiteDescriptionCommand>(createSiteDescriptionDto);
            var siteDescription = await Mediator.Send(command);
            return Ok(siteDescription);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
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
