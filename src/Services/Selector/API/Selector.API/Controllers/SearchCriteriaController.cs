using Selector.Core.Application.Features.SearchCriteries.Queries.GetAllSearchCriteries;
using Selector.Core.Application.Features.SearchCriteries.Queries.GetSearchCriteriaById;

namespace Selector.API.Controllers
{
    public class SearchCriteriaController : BaseController
    {
        private readonly ILogger<SearchCriteriaController> _logger;

        public SearchCriteriaController(
            ILogger<SearchCriteriaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllSearchCriteriesQuery();
            return await Mediator.Send(query, cancellationToken) is IReadOnlyList<SearchCriteriaModel> data
                ? Ok(data)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var query = new GetSearchCriteriaByIdQuery
            {
                Id = id
            };
            return await Mediator.Send(query, cancellationToken) is SearchCriteriaModel model
                ? Ok(model)
                : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
