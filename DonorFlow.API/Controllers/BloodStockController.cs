using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DonorFlow.Application.Queries.BloodStockQueries.GetBloodStockAll;

namespace DonorFlow.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/blood")]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetBloodStockAllQuery();
            var result = await _mediator.Send(query);

            return result.Success ? Ok(result) : NotFound(result.Message);
        }
    }
}
